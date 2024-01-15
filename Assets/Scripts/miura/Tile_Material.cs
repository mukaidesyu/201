// パネルのスプライトを変更するスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile_Material : MonoBehaviour
{
    enum TileStatus
    {
        Grass = 0,
        Up,
        Left,
        Down,
        Right,
        Warm,
        Side,
        RightUp,
        DownRight,
        TRight,
        LeftUp,
        Tup,
        LeftDown,
        TLeft,
        TDown,
        Cross,
        Ike,
    };

    enum Ike
    {
        Ike_1,
        Ike_2,
        Ike_3,
        Ike_4,
    };

    enum Grass
    {
        grass_1,
        grass_2,
        grass_3,
        grass_4,
        grass_5,
    };

    Material[] tmp;
    TileStatus status;
    Ike ike;
    Grass grass;



    [SerializeField] bool UpPanel;
    [SerializeField] bool RightPanel;
    [SerializeField] bool LeftPanel;
    [SerializeField] bool DownPanel;

    [SerializeField] private int id;

    public Material[] Materials;
    public Material[] Ike_Materials;
    public Material[] Grass_Materials;
    public GameObject[] Terrain;
    public GameObject nowTerrain;
    public GameObject nowGrass;

    Tilemanager tilemanager;

    bool isGoal = false;
    GameObject instance;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        Material[] tmp = gameObject.GetComponent<Renderer>().materials;
        status = TileStatus.Grass;
        ike = Ike.Ike_1;

        //タイルのid取得
        id = this.gameObject.GetComponent<Tilemanager>().GetTileNo();

        // テレイン作成
        EventStatus eveSta = GetComponent<Tilemanager>().GetEvent();
        PanelStatus paneSta = GetComponent<Tilemanager>().GetPanelStatus();


        tilemanager = GetComponent<Tilemanager>();

        isGoal = tilemanager.GetGoalFlag();
        if (isGoal)
        {
            GameObject house = Resources.Load<GameObject>("CountryHouse");
            GameObject temp = GameObject.Instantiate(house, new Vector3(this.transform.position.x, transform.position.y - 10.0f, transform.position.z), Quaternion.Euler(0, 90, 0));
            temp.transform.SetParent(this.gameObject.transform);
        }
        else if (paneSta != PanelStatus.Nothing)
        {
            nowTerrain = Instantiate(Terrain[(int)status]);
            nowTerrain.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 10, this.gameObject.transform.position.z);
        }

        // 草作成
        if (eveSta == EventStatus.Kinoko || eveSta == EventStatus.Sakana || eveSta == EventStatus.Kari1 || eveSta == EventStatus.Kari2 || eveSta == EventStatus.Kari3 || eveSta == EventStatus.Zasso)
        {
            GameObject temp = (GameObject)Resources.Load("Terrein/Prefabs/GrassEvent");
            nowGrass = Instantiate(temp, new Vector3(this.transform.position.x, transform.position.y - 10.0f, transform.position.z)
                , Quaternion.Euler(0, 0, 0));
            nowGrass.transform.SetParent(this.gameObject.transform, true);
        }

        if (status == TileStatus.Grass)
        {
            GetComponent<Renderer>().material = Grass_Materials[(int)grass];
        }

        SetMaterial(tilemanager.PutWalkFlag());
    } 

    // Update is called once per frame
    void Update()
    {
        if(status == TileStatus.Ike)
        {
            GetComponent<Renderer>().material = Ike_Materials[(int)ike];

            seconds += Time.deltaTime;
            if (seconds >= 0.5)
            {
                seconds = 0;
                ike++;
                if (ike > Ike.Ike_4)
                {
                    ike = Ike.Ike_1;
                }
            }
        }
        else
        {
            GetComponent<Renderer>().material = Materials[(int)status];
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
        {
            SetMaterial(tilemanager.PutWalkFlag());
        }
    }

    // タイルが変更するたびに呼ぶといいかも
    public void SetMaterial(bool isWalk)
    {
        if (isWalk)
        {
            status = TileStatus.Up;
           
            int cols = GameObject.Find("Tile").GetComponent<tile>()._cols;//列
            int rows = GameObject.Find("Tile").GetComponent<tile>()._rows;//行
            int road = 0;
            /*Debug.Log("通った");*/
            
            if ((id + 1) % cols == 0)//上の例外処理
            {
                UpPanel = false;
            }
            else
            {
                UpPanel = GameObject.Find("panel" + (id + 1) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag(); // 上のパネルを取得
                if (UpPanel == true)
                { road += 1; }
            }

            if (cols * (rows - 1) <= id)//右の例外処理
            {
                RightPanel = false;
            }
            else
            {
                RightPanel = GameObject.Find("panel" + (id + cols) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag();  // 右のパネルを取得
                if (RightPanel == true)
                { road += 10; }
            }

            if (id % cols == 0)//下の例外処理
            {
                DownPanel = false;
            }
            else
            {
                DownPanel = GameObject.Find("panel" + (id - 1) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag();  // 下のパネルを取得
                if (DownPanel == true)
                { road += 100; }
            }

            if (cols > id)//左の例外処理
            {
                LeftPanel = false;
            }
            else
            {
                LeftPanel = GameObject.Find("panel" + (id + -cols) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag(); // 左のパネルを取得
                if (LeftPanel == true)
                { road += 1000; }
            }
            
            //左下右上の順
            switch (road)
            {
                case 0:
                    status = TileStatus.Grass;
                    break;
                case 1://上
                    status = TileStatus.Up;
                    break;
                case 10://右
                    status = TileStatus.Right;
                    break;
                case 11://右上
                    status = TileStatus.RightUp;
                    break;
                case 100://下
                    status = TileStatus.Down;
                    break;
                case 101://下上
                    status = TileStatus.Warm;    
                    break;
                case 110://下右
                    status = TileStatus.DownRight;
                    break;
                case 111://下右上
                    status = TileStatus.TRight;
                    break;
                case 1000://左
                    status = TileStatus.Left;
                    break;
                case 1001://左上
                    status = TileStatus.LeftUp;
                    break;
                case 1010://左右
                    status = TileStatus.Side;
                    break;
                case 1011://左右上
                    status = TileStatus.Tup;
                    break;
                case 1100://左下
                    status = TileStatus.LeftDown;
                    break;
                case 1101://左下上
                    status = TileStatus.TLeft;
                    break;
                case 1110://左下右 
                    status = TileStatus.TDown;
                    break;
                case 1111://左下右上 
                    status = TileStatus.Cross;
                    break;
            }

            EventStatus eveSta = this.GetComponent<Tilemanager>().GetEvent();
            if (eveSta == EventStatus.Kinoko_Got || eveSta == EventStatus.Sakana_Got || eveSta == EventStatus.Kari1_Got || eveSta == EventStatus.Kari2_Got || eveSta == EventStatus.Kari3_Got || eveSta == EventStatus.Zasso_Got)
            {
               Destroy(nowGrass,0.0f);
            }
            CubeSet();

        }
        else
        {
            EventStatus eventSta = this.GetComponent<Tilemanager>().GetEvent();
            if (eventSta == EventStatus.Ike)
            {
                status = TileStatus.Ike;
            }
            else
            {
                status = TileStatus.Grass;
            }
        }
    }
    public void CubeSet()
    {
        // 例外処理
        if (isGoal == true)return;

        Destroy(nowTerrain);
        // nowTerrain = GameObject.Instantiate(Terrain[(int)status], new Vector3(this.transform.position.x, transform.position.y - 10.0f, transform.position.z),Quaternion.identity);
        // nowTerrain.transform.SetParent(this.gameObject.transform, true);
        nowTerrain = Instantiate(Terrain[(int)status]);
        nowTerrain.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 10, this.gameObject.transform.position.z);
    }
}

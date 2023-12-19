// パネルのスプライトを変更するスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Material[] tmp;
    TileStatus status;

    [SerializeField]bool UpPanel;
    [SerializeField]bool RightPanel;
    [SerializeField]bool LeftPanel;
    [SerializeField]bool DownPanel;

    [SerializeField]  private int id;

    public Material[] Materials;
    public GameObject nowTerrain;
    public GameObject nowGrass;
    // Start is called before the first frame update
    void Start()
    {
        Material[] tmp = gameObject.GetComponent<Renderer>().materials;
        status = TileStatus.Grass;
        //タイルのid取得
        id = this.gameObject.GetComponent<Tilemanager>().GetTileNo();

        // テレイン作成
        EventStatus eveSta = GetComponent<Tilemanager>().GetEvent();
        PanelStatus paneSta = GetComponent<Tilemanager>().GetPanelStatus();
        if (paneSta != PanelStatus.Nothing)
        {
            GameObject temp = (GameObject)Resources.Load("Terrein/Prefabs/tileDown");
            nowTerrain = Instantiate(temp, new Vector3(this.transform.position.x, transform.position.y - 10.0f, transform.position.z)
                , Quaternion.Euler(0, 0, 0));
            nowTerrain.transform.SetParent(this.gameObject.transform, true);
        }

        // 草作成
        if (eveSta == EventStatus.Kinoko || eveSta == EventStatus.Sakana || eveSta == EventStatus.Kari1 || eveSta == EventStatus.Kari2 || eveSta == EventStatus.Kari3 || eveSta == EventStatus.Zasso)
        {
            GameObject temp = (GameObject)Resources.Load("Terrein/Prefabs/GrassEvent");
            nowGrass = Instantiate(temp, new Vector3(this.transform.position.x, transform.position.y - 10.0f, transform.position.z)
                , Quaternion.Euler(0, 0, 0));
            nowGrass.transform.SetParent(this.gameObject.transform, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material = Materials[(int)status];
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

        }
        else
        {
            EventStatus eventSta = this.GetComponent<Tilemanager>().GetEvent();
            PanelStatus panelSta = this.GetComponent<Tilemanager>().GetPanelStatus();
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
}

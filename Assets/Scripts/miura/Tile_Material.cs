// �p�l���̃X�v���C�g��ύX����X�N���v�g
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
        //�^�C����id�擾
        id = this.gameObject.GetComponent<Tilemanager>().GetTileNo();

        // �e���C���쐬
        EventStatus eveSta = GetComponent<Tilemanager>().GetEvent();
        PanelStatus paneSta = GetComponent<Tilemanager>().GetPanelStatus();
        if (paneSta != PanelStatus.Nothing)
        {
            GameObject temp = (GameObject)Resources.Load("Terrein/Prefabs/tileDown");
            nowTerrain = Instantiate(temp, new Vector3(this.transform.position.x, transform.position.y - 10.0f, transform.position.z)
                , Quaternion.Euler(0, 0, 0));
            nowTerrain.transform.SetParent(this.gameObject.transform, true);
        }

        // ���쐬
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

    // �^�C�����ύX���邽�тɌĂԂƂ�������
    public void SetMaterial(bool isWalk)
    {
        if (isWalk)
        {
            status = TileStatus.Up;
           
            int cols = GameObject.Find("Tile").GetComponent<tile>()._cols;//��
            int rows = GameObject.Find("Tile").GetComponent<tile>()._rows;//�s
            int road = 0;
            /*Debug.Log("�ʂ���");*/
            
            if ((id + 1) % cols == 0)//��̗�O����
            {
                UpPanel = false;
            }
            else
            {
                UpPanel = GameObject.Find("panel" + (id + 1) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag(); // ��̃p�l�����擾
                if (UpPanel == true)
                { road += 1; }
            }

            if (cols * (rows - 1) <= id)//�E�̗�O����
            {
                RightPanel = false;
            }
            else
            {
                RightPanel = GameObject.Find("panel" + (id + cols) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag();  // �E�̃p�l�����擾
                if (RightPanel == true)
                { road += 10; }
            }

            if (id % cols == 0)//���̗�O����
            {
                DownPanel = false;
            }
            else
            {
                DownPanel = GameObject.Find("panel" + (id - 1) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag();  // ���̃p�l�����擾
                if (DownPanel == true)
                { road += 100; }
            }

            if (cols > id)//���̗�O����
            {
                LeftPanel = false;
            }
            else
            {
                LeftPanel = GameObject.Find("panel" + (id + -cols) + "(Clone)").GetComponent<Tilemanager>().PutWalkFlag(); // ���̃p�l�����擾
                if (LeftPanel == true)
                { road += 1000; }
            }
            
            //�����E��̏�
            switch (road)
            {
                case 0:
                    status = TileStatus.Grass;
                    break;
                case 1://��
                    status = TileStatus.Up;
                    break;
                case 10://�E
                    status = TileStatus.Right;
                    break;
                case 11://�E��
                    status = TileStatus.RightUp;
                    break;
                case 100://��
                    status = TileStatus.Down;
                    break;
                case 101://����
                    status = TileStatus.Warm;    
                    break;
                case 110://���E
                    status = TileStatus.DownRight;
                    break;
                case 111://���E��
                    status = TileStatus.TRight;
                    break;
                case 1000://��
                    status = TileStatus.Left;
                    break;
                case 1001://����
                    status = TileStatus.LeftUp;
                    break;
                case 1010://���E
                    status = TileStatus.Side;
                    break;
                case 1011://���E��
                    status = TileStatus.Tup;
                    break;
                case 1100://����
                    status = TileStatus.LeftDown;
                    break;
                case 1101://������
                    status = TileStatus.TLeft;
                    break;
                case 1110://�����E 
                    status = TileStatus.TDown;
                    break;
                case 1111://�����E�� 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour, Clickable
{
    [SerializeField]  private int TileNo; // ���ʔԍ�

    // �L�ƘA�g����n�̊֐�
    // ��������
    public bool walkflag = false; // ������s�[�X���ǂ���
    public bool Goalflag = false; // �������S�[���Ȃ̂��ǂ���
    bool nowPut = false; // ���u�������ǂ���
    bool onTile = false; // �^�C������������ǂ���
    bool walkedNeko = false; // �L�����邢�����ǂ���
    public EventStatus Event = EventStatus.None;//�C�x���g�����邩�ۂ�
    PanelStatus panelStatus = PanelStatus.Walkable; // 0:�Q�[�����ɕ\�����Ȃ� 1:�\�����邯�Ǖ����Ȃ� 2:���ʂ̓��ɂȂ�
    [SerializeField] GameObject eventObject;

    Eventmanager eventmanager;

    public void WalkFlag()
    {
        // �\�����ĂȂ���Ԃ͏������Ȃ�
        if (panelStatus == PanelStatus.CantWalk) return;

        // �N���b�N�������̏���
        walkflag = true;
    }

    public int PutNo()
    {
        return TileNo;
    }

    public bool PutWalkFlag()
    {
        return walkflag;
    }

    public void Startpanel()
    {
        walkflag = true;
    }

    public void Goalpanel()
    {
        Goalflag = true;
    }
    public bool GetGoalFlag() // 11/20�O�Y�ǋL
    {
        return Goalflag;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (panelStatus == PanelStatus.Nothing)// "����"�̏�Ԃ̂Ƃ��͕\�����Ȃ�
        {
            GetComponent<MeshRenderer>().enabled = false; // ����������NavMesh������H�H
        }
        else if (Event == EventStatus.Kinoko || Event == EventStatus.Sakana || Event == EventStatus.Kari1
            || Event == EventStatus.Kari2 || Event == EventStatus.Kari3)
        {
            GameObject tmp = (GameObject)Resources.Load("Item");
            tmp.GetComponent<ItemSprite>().SetEventSta(Event);
            eventObject = Instantiate(tmp, new Vector3(this.transform.position.x,transform.position.y + 0.1f,transform.position.z)
                ,Quaternion.Euler(80,0,0),this.gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (eventObject != null)
        {
            // ���t���[���C�x���g�X�V
            eventObject.GetComponent<ItemSprite>().SetEventSta(Event);
        }

        if (panelStatus != PanelStatus.CantWalk) 
        {

            // �p�l���̏�Ԃɂ���ĐF���ς��
            // �^�C���̃^�O���ς��
            switch (walkflag)
            {
                case true:
                    this.gameObject.layer = 6;
                    break;
                case false:
                    this.gameObject.layer = 7;
                    break;
            }
        }
        else// �p�l���̏󋵂�CantWalk���Ɛ�΂ɕ�����悤�ɂȂ�Ȃ�
        {
            this.gameObject.layer = 7; // 7��NotWalk
        }

        this.GetComponent<Tile_Material>().SetMaterial(walkflag);

        if (Goalflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }

    // �Q�b�^�[�ƃZ�b�^�[
    // �^�C��NO
    public void SetTileNo(int no)
    {
        TileNo = no;
    }
    public int GetTileNo()
    {
        return TileNo;
    }

    // �L���g��������
    public void SetNowPut(bool set)
    {
        nowPut = set;
    }
    public bool GetNowPut()
    {
        return nowPut;
    }
    public void SetOnTile(bool set)
    {
        onTile = set;
    }
    public bool GetOnTile()
    {
        return onTile;
    }
    public void SetWalkedNeko(bool set)
    {
        walkedNeko = set;
    }
    public bool GetWalkedNeko()
    {
        return walkedNeko;
    }
    public void SetEvent(bool set)
    {
        walkedNeko = set;
    }

    //�C�x���g�̎�ގ擾
    public EventStatus GetEvent()
    { 
        return Event;
    }
    public void SetEvent(EventStatus set)
    {
        Event = set;
    }
    public PanelStatus GetPanelStatus()
    {
        return panelStatus;
    }
    public void SetPanelStatus(PanelStatus status)
    {
        panelStatus = status;
    }
}

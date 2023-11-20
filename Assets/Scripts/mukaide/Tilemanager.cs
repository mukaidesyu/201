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

    public void WalkFlag()
    {
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
    bool GetGoalFlag() // 11/20�O�Y�ǋL
    {
        return Goalflag;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    public int _rows = 3;
    public int _cols = 3;
    private int i = 0;

    Rigidbody rb;

    // ���������^�C���S���̃��X�g
    List<GameObject> cd = new List<GameObject>();

    private void Awake()
    {
        for (int row = -5; row < _rows -5; row++)
        {
            for (int col = -5; col < _cols -5; col++)
            {
                _tile.name = "panel" + i;
                // �^�C����ID��ݒ肷��
                _tile.GetComponent<Tilemanager>().SetTileNo(i);

                //�p�l���̐���
                Instantiate(_tile, new Vector3(row,0, col),
                    Quaternion.Euler(90, 0, 0), transform);
                i++;
            }
        }

    }
    private void Start()
    {
        for(int j = 0;j < i;j++)
        {
            cd.Add(transform.GetChild(j).gameObject);
            if(j <= 0)
            {
                cd[j].GetComponent<Tilemanager>().Startpanel();
            }
            if(j == i-1)
            {
                cd[j].GetComponent<Tilemanager>().Goalpanel();
                // �L�ɃS�[���̃^�C����n��
                GameObject.Find("Neko").GetComponent<Neko_NavMesh>().SetGoal(cd[j]);
            }
        }

        //Rigidbody�̎擾
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

    }

    // �c���̃Q�b�^�[�ƃZ�b�^�[
    public int GetRows()
    {
        return _rows;
    }
    public int GetCols()
    {
        return _cols;
    }

    // ������s�[�X���Ȃ񂩂������Ԃ�
    public GameObject GetOnTile()
    {
        List < GameObject > tmp = new List<GameObject>();
        int trueCount = 0;
        for (int j = 0; j < i; j++)
        {
            // �^�C��������Ă邩���f
            if(cd[j].GetComponent<Tilemanager>().GetOnTile() == true)
            {
                tmp.Add(cd[j].gameObject);
                trueCount++;
            }
        }


        // ������^�C���̒����烉���_����1�����n��
        if(trueCount <= 0) return null;
        int rand = Random.Range(1, trueCount);
        return tmp[rand - 1].gameObject;

        // �����������ă��X�g��delete����Ȃ��H�H
    }

    // �u�����s�[�X�̒���1�ԉ����s�[�X��Ԃ�
    public GameObject GetFarTile(GameObject onTile) // �����F1�Ɍ��߂���̔�����s�[�X
    {
        List<GameObject> tmp = new List<GameObject>();
        for (int j = 0; j < i; j++)
        {
            // ���u�����^�C���S�Ă��擾
            if (cd[j].GetComponent<Tilemanager>().GetNowPut() == true)
            {
                tmp.Add(cd[j].gameObject);
            }
        }

        GameObject farTile = tmp[0].gameObject;

        for (int j = 1; j < tmp.Count ;j++)
        {
            // ��1�ԉ����^�C����荡�т̃^�C��������������
            if (Vector3.Distance(farTile.transform.position,onTile.transform.position)
                < Vector3.Distance(tmp[j].transform.position, onTile.transform.position))
            {
                farTile = tmp[j].gameObject;// ����ւ�
            }
            else if (Vector3.Distance(farTile.transform.position, onTile.transform.position)
                == Vector3.Distance(tmp[j].transform.position, onTile.transform.position)) // �ꏏ��������50%�œ���ւ�
            {
                int rand = Random.Range(0, 1);
                if(rand == 0)
                {
                    farTile = tmp[j].gameObject;
                }
            }
        }

        return farTile.gameObject;
    }


    // �S���̃^�C�������u���ĂȂ��t���O�ɂ���
    public void EndNowPut()
    {
        for (int j = 0; j < i; j++)
        {
            if (cd[j].GetComponent<Tilemanager>().GetNowPut() == true)
            {
                cd[j].GetComponent<Tilemanager>().SetNowPut(false);
            }

            if (cd[j].GetComponent<Tilemanager>().GetOnTile() == true)
            {
                cd[j].GetComponent<Tilemanager>().SetOnTile(false);
            }
        }

    }
}

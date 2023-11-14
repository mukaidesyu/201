using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    private int i = 0;

    // ���������^�C���S���̃��X�g
    List<GameObject> cd = new List<GameObject>();

    private void Awake()
    {
        for (int row = -5; row < _rows; row++)
        {
            for (int col = -5; col < _cols; col++)
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
            }
        }

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

    public GameObject GetOnTile()
    {
        List < GameObject > tmp = new List<GameObject>();
        for (int j = 0; j < i; j++)
        {
            if(cd[j].GetComponent<Tilemanager>().GetOnTile() == true)
            {

            }

        }

    }
}

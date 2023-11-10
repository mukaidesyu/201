using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    private int i = 0;

    List<GameObject> cd = new List<GameObject>();
    List<bool> flag = new List<bool>();

    private void Awake()
    {
        for (int row = -5; row < _rows; row++)
        {
            for (int col = -5; col < _cols; col++)
            {
                _tile.name = "panel" + i;
                //ƒpƒlƒ‹‚Ì¶¬
                Instantiate(_tile, new Vector3(row, col, 0),
                    Quaternion.identity, transform);
                i++;
            }
        }

    }
    private void Start()
    {
        for(int j = 0;j < i;j++)
        {
            cd.Add(transform.GetChild(j).gameObject);
            flag.Add(cd[j].GetComponent<Tilemanager>().PutWalkFlag());
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
        for (int j = 0; j < i ; j++)
        {
            flag[j] = cd[j].GetComponent<Tilemanager>().PutWalkFlag();
            //Debug.Log(flag[j]);
        }

        
    }

}

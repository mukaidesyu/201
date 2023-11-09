using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    private int i = 1;

    List<GameObject> cd = new List<GameObject>();
    List<bool> flag = new List<bool>();


    private void Awake()
    {
        for (int row = -5; row < _rows; row++)
        {
            for (int col = -5; col < _cols; col++)
            {
                //ƒpƒlƒ‹‚Ì¶¬
                Instantiate(_tile, new Vector3(row, col, 0),
                    Quaternion.identity, transform);
                _tile.name = "panel"+ i;
                i++;
            }
        }

    }
    private void Start()
    {
        for(int j = 0;j < i-1;j++)
        {
            Debug.Log(j);
            cd.Add(transform.GetChild(j).gameObject);
            flag.Add(cd[j].GetComponent<Tilemanager>().PutWalkFlag());
        }

    }

    private void Update()
    {
      //  if(Input.GetKeyDown(KeyCode.Return))
      //  {
      //      for (int j = 0; j < i-1; j++)
      //      {
      //          flag.Add(cd[i].GetComponent<Tilemanager>().PutWalkFlag());             
      //      }
      //  }
    }

}

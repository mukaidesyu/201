using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    private int i = 1;

    List<GameObject> tilelist = new List<GameObject>();

    private void Awake()
    {
        for (int row = -3; row < _rows; row++)
        {
            for (int col = -3; col < _cols; col++)
            {
                //ƒpƒlƒ‹‚Ì¶¬
                Instantiate(_tile, new Vector3(row, col, 0),
                    Quaternion.identity, transform);
                _tile.name = "panel"+ i;
                tilelist.Add(_tile);
                i++;
            }
        }
    }

    public void Select()
    {

        tilelist[1].GetComponent<Tilemanager>();
    }


}

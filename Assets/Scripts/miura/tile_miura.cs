using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_miura : MonoBehaviour
{
    [SerializeField] private GameObject _tile;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    int i = 0;

    private void Start()
    {
        for (int row = -3; row < _rows; row++)
        {
            for (int col = -3; col < _cols; col++)
            {
                //パネルの生成
                Instantiate(_tile, new Vector3(row, col, 0),
                    Quaternion.identity, transform);
                i++;

                _tile.name = ""+i;
            }
        }
    }


}

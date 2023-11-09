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
        for (int row = - _rows / 2 ; row < _rows - row; row++)
        {
            for (int col = - _cols / 2; col < _cols - col; col++)
            {
                //ƒpƒlƒ‹‚Ì¶¬
                Instantiate(_tile, new Vector3(row, 0,col),
                   Quaternion.Euler(-90,0,0), transform);
                i++;

                _tile.name = ""+i;
            }
        }
    }


}

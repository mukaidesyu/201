using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    [SerializeField] private int _rows = 3;
    [SerializeField] private int _cols = 3;
    private int i = 1;


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



}

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
        for (int row = 0 ; row < _rows; row++)
        {
            for (int col = 0; col < _cols ; col++)
            {
                _tile.name = "" + i;
                _tile.GetComponent<Tile_select>().SetTileID(i);
                //ÉpÉlÉãÇÃê∂ê¨
                Instantiate(_tile, new Vector3(row, 0,col),
                   Quaternion.Euler(90,0,0), transform);
                i++;
            }
        }
    }


}

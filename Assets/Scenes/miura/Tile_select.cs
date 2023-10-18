using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_select : MonoBehaviour
{
    public enum TileState
    {
       Select_None = 0,
       Select = 1,
       Select_Before 
    }

    [SerializeField] private TileState state;

    // Start is called before the first frame update
    void Start()
    {
        //　パネルが出る時にとりあえず初期化、必要か？
        
    }

    // Update is called once per frame
    void Update()
    {
        // パネルの状態によって色が変わる
        switch (state)
        {
            case TileState.Select_None:
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
            case TileState.Select:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case TileState.Select_Before:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_select : MonoBehaviour
{
    // 歩けるパネルかどうか
    public bool IsWalk;

    // Start is called before the first frame update
    void Start()
    {
        //　パネルが出る時にとりあえず初期化、必要か？
        IsWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        // パネルの状態によって色が変わる
        switch (IsWalk)
        {
            case true:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case false:
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }
}

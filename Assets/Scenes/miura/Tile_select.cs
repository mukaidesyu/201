using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_select : MonoBehaviour
{
    // 歩けるパネルかどうか
    public bool IsWalk;
    // タイルのID
    [SerializeField]int tileID;

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
        // タイルのタグも変わる
        switch (IsWalk)
        {
            case true:
                this.gameObject.layer = 6;
                break;
            case false:
                this.gameObject.layer = 7;
                break;
        }

        this.GetComponent<Tile_Material>().SetMaterial(IsWalk);
    }

    public void SetTileID(int no)
    {
        tileID = no;
    }
}

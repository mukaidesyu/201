using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour, Clickable
{
    // 歩けるやつ
    public bool walkflag = false;

    public int TileNo;

    public int putno = 0;

    public bool Goalflag = false;

    public void WalkFlag()
    {
        // クリックした時の処理
        walkflag = true;
    }

    public int PutNo()
    {
        return TileNo;
    }

    public bool PutWalkFlag()
    {
        return walkflag;
    }

    public void Startpanel()
    {
        walkflag = true;
    }

    public void Goalpanel()
    {
        Goalflag = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
  
        TileNo++;
    }

    // Update is called once per frame
    void Update()
    {
        // パネルの状態によって色が変わる
        // タイルのタグも変わる
        switch (walkflag)
        {
            case true:
                this.gameObject.layer = 6;
                break;
            case false:
                this.gameObject.layer = 7;
                break;
        }

        this.GetComponent<Tile_Material>().SetMaterial(walkflag);

        if (Goalflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }


}

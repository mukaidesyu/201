using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour, Clickable
{
    [SerializeField]  private int TileNo; // 識別番号

    // 猫と連携する系の関数
    // 歩けるやつ
    public bool walkflag = false; // 歩けるピースかどうか
    public bool Goalflag = false; // 自分かゴールなのかどうか
    bool nowPut = false; // 今置いたかどうか
    bool onTile = false; // タイルが被ったかどうか
    bool walkedNeko = false; // 猫があるいたかどうか
    public EventStatus Event = EventStatus.None;//イベントがあるか否か
    PanelStatus panelStatus = PanelStatus.Walkable; // 0:ゲーム内に表示しない 1:表示するけど歩けない 2:普通の道になる
    GameObject eventObject;
    [SerializeField] GameObject terrein;

    Eventmanager eventmanager;

    public void WalkFlag()
    {
        // 表示してない状態は処理しない
        if (panelStatus == PanelStatus.CantWalk) return;

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
    public bool GetGoalFlag() // 11/20三浦追記
    {
        return Goalflag;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (panelStatus == PanelStatus.Nothing)// "無い"の状態のときは表示しない
        {
            GetComponent<MeshRenderer>().enabled = false; // もしかしてNavMeshこわれる？？
        }
        else if (Goalflag == true)
        {
            GameObject tmp = (GameObject)Resources.Load("Home");
            Instantiate(tmp, new Vector3(this.transform.position.x, transform.position.y + 0.1f, transform.position.z + 0.3f)
                , Quaternion.Euler(80, 0, 0), this.gameObject.transform);

        }
        else if (Event == EventStatus.Kinoko || Event == EventStatus.Sakana || Event == EventStatus.Kari1
            || Event == EventStatus.Kari2 || Event == EventStatus.Kari3 || Event == EventStatus.Rock ||
            Event == EventStatus.Zasso)
        {
            GameObject tmp = (GameObject)Resources.Load("Item");
            tmp.GetComponent<ItemSprite>().SetEventSta(Event);
            eventObject = Instantiate(tmp, new Vector3(this.transform.position.x,transform.position.y + 0.1f,transform.position.z)
                ,Quaternion.Euler(80,0,0),this.gameObject.transform);
        }
        else if (Event == EventStatus.Ike)
        {
            GameObject tmp = (GameObject)Resources.Load("Item");
            tmp.GetComponent<ItemSprite>().SetEventSta(Event);
        }


        ChangeTile();
    }

    // Update is called once per frame
    void Update()
    {

        if (eventObject != null)
        {
            // 毎フレームイベント更新
            eventObject.GetComponent<ItemSprite>().SetEventSta(Event);
        }

        if (panelStatus != PanelStatus.CantWalk) // CantWalkじゃなければ変更できる
        {
            switch (walkflag)
            {
                case true:
                    this.gameObject.layer = 6;
                    break;
                case false:
                    this.gameObject.layer = 7;
                    break;
            }
        }
        else// パネルの状況がCantWalkだと歩けるようにならない
        {
            this.gameObject.layer = 7; // 7はNotWalk
        }

        

        if (Goalflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }

    public void ChangeTile()
    {
        this.GetComponent<Tile_Material>().SetMaterial(walkflag);
    }

    // ゲッターとセッター
    // タイルNO
    public void SetTileNo(int no)
    {
        TileNo = no;
    }
    public int GetTileNo()
    {
        return TileNo;
    }

    // 猫が使いそうな
    public void SetNowPut(bool set)
    {
        nowPut = set;
    }
    public bool GetNowPut()
    {
        return nowPut;
    }
    public void SetOnTile(bool set)
    {
        onTile = set;
    }
    public bool GetOnTile()
    {
        return onTile;
    }
    public void SetWalkedNeko(bool set)
    {
        walkedNeko = set;
    }
    public bool GetWalkedNeko()
    {
        return walkedNeko;
    }
    public void SetEvent(bool set)
    {
        walkedNeko = set;
    }

    //イベントの種類取得
    public EventStatus GetEvent()
    { 
        return Event;
    }
    public void SetEvent(EventStatus set)
    {
        Event = set;
    }
    public PanelStatus GetPanelStatus()
    {
        return panelStatus;
    }
    public void SetPanelStatus(PanelStatus status)
    {
        panelStatus = status;
    }
}

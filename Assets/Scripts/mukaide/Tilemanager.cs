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
    [SerializeField] GameObject eventObject;

    Eventmanager eventmanager;

    public void WalkFlag()
    {
        // 表示してない状態は処理しない
        if (panelStatus == PanelStatus.CantWalk) return;

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
    public bool GetGoalFlag() // 11/20三浦追記
    {
        return Goalflag;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (panelStatus == PanelStatus.Nothing)// "無い"の状態のときは表示しない
        {
            GetComponent<MeshRenderer>().enabled = false; // もしかしてNavMeshこわれる？？
        }
        else if (Event == EventStatus.Kinoko || Event == EventStatus.Sakana || Event == EventStatus.Kari1
            || Event == EventStatus.Kari2 || Event == EventStatus.Kari3)
        {
            GameObject tmp = (GameObject)Resources.Load("Item");
            tmp.GetComponent<ItemSprite>().SetEventSta(Event);
            eventObject = Instantiate(tmp, new Vector3(this.transform.position.x,transform.position.y + 0.1f,transform.position.z)
                ,Quaternion.Euler(80,0,0),this.gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (eventObject != null)
        {
            // 毎フレームイベント更新
            eventObject.GetComponent<ItemSprite>().SetEventSta(Event);
        }

        if (panelStatus != PanelStatus.CantWalk) 
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
        }
        else// パネルの状況がCantWalkだと絶対に歩けるようにならない
        {
            this.gameObject.layer = 7; // 7はNotWalk
        }

        this.GetComponent<Tile_Material>().SetMaterial(walkflag);

        if (Goalflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Clickable
{
    void WalkFlag();
    int PutNo();
    bool PutWalkFlag();

    void SetNowPut(bool set);
    void SetOnTile(bool set);

    EventStatus GetEvent();
    PanelStatus GetPanelStatus();
}

public class PieceRay : MonoBehaviour
{
    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;

    public bool putflag = false;

    Piece piece;

    [SerializeField] ParticleSystem ef;

    EventStatus ev;
    PanelStatus panelstatus;

    Move move;

    // Start is called before the first frame update
    void Start()
    {
        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>();
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>();
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>();
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>();

        move = GameObject.Find("player").GetComponent<Move>();

        piece = gameObject.transform.parent.gameObject.GetComponent<Piece>();
    }

    // Update is called once per frame
    void Update()
    {
        putflag = false;
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 10.0f))
        {
            // クールタイム中かどうか判断する
            if (GameObject.Find("player").GetComponent<Move>().GetUnpossible())
            {

                Clickable c = hit.collider.gameObject.GetComponent<Clickable>();
               
                if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
                {
                    putflag = c.PutWalkFlag();
                    ev = c.GetEvent();
                    panelstatus = c.GetPanelStatus();

                    if(piece.flage() == true)
                    {
                        this.GetComponent<Renderer>().material.color = new Color(1,0,0,1);
                    }
                    else
                    {
                        this.GetComponent<Renderer>().material.color = Color.white;
                    }


                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
                    {
                        if (piece.flagp() == true && piece.flage() == false && move.Rotflag() == true)
                        {
                            //Debug.Log("ピースレイ");
                            c.WalkFlag();
                            c.PutNo();
                            c.SetNowPut(true);

                            ParticleSystem newParticle = Instantiate(ef);
                            ParticleSystem newParticle1 = Instantiate(ef);

                            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
                            newParticle.transform.position = this.transform.position;
                            newParticle1.transform.position = this.transform.position;
                            // パーティクルを発生させる。
                            newParticle.Play();
                            newParticle1.Play();
                            // インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
                            Destroy(newParticle.gameObject, 1.0f);
                            Destroy(newParticle1.gameObject, 1.0f);

                            if (putflag == true)
                            {
                                c.SetOnTile(true);
                            }
                        }

                    }

                }
            }

        }

    }

    public EventStatus Ev()
    {
        return ev;
    }

    public PanelStatus Ps()
    {
        return panelstatus;
    }

    public bool pfl()
    {
        return putflag;
    }

}

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
}

public class PieceRay : MonoBehaviour
{
    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;

    public bool putflag = false;

    Piece piece;

    // Start is called before the first frame update
    void Start()
    {
        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>();
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>();
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>();
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>();

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
                    if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown("joystick button 1"))
                    {
                        if (piece.flagp() == true)
                        {
                            Debug.Log("推す");
                            c.WalkFlag();
                            c.PutNo();
                            c.SetNowPut(true);
                            if (putflag == true)
                            {
                                c.SetOnTile(true);
                            }
                        }

                    }

                }
                if (hit.collider.CompareTag("tile"))
                {
                    // 緑色に変更する
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            }

        }

    }


    public bool pfl()
    {
        return putflag;
    }

}

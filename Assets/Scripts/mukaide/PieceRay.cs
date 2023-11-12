using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Clickable
{
    void WalkFlag();
    int PutNo();
    bool PutWalkFlag();
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
            if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
            {
                //Debug.Log(hit.collider.gameObject);
                Debug.DrawRay(transform.position, Vector3.down, Color.red);
                Clickable c = hit.collider.gameObject.GetComponent<Clickable>();
                putflag = true;// �ύX�O//putflag = c.PutWalkFlag();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (piece.flagp() == true)// ���̕ӌ���
                    {
                        c.WalkFlag();
                        c.PutNo();
                        Debug.Log("�F�ς���");
                    }

                }

            }
            if (hit.collider.CompareTag("tile"))
            {
                // �ΐF�ɕύX����
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        
        }

    }


    public bool pfl()
    {
        return putflag;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float distance = 1.0f;
    public Vector2 move;
    private Vector3 targetPos;
    public bool putflag = true;

    Spawner spawner;    // スポナー
    Piece activePiece;  // 生成されたピース 
    GameObject Pice;
    GameObject old;

    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;

    private void Start()
    {
        targetPos = transform.position;

        // スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();
        if (!activePiece)
        {
            activePiece = spawner.SpawnPiece(this.gameObject);
            Pice = activePiece.gameObject;
        }

        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>();
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>();
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>();
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>();
    }

    void Update()
    {
        RaycastHit hit;
           
         //移動
        if (Input.GetKeyDown(KeyCode.W)||Input.GetAxis("Vertical") > 0.1f)
        {
            Debug.Log(Input.GetAxis("Vertical"));
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(0, 1, 0) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetAxis("Vertical") < -0.1f)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(0, -1, 0) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(-1, 0, 0) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                {
                    old = hit.collider.gameObject;
                }
            }
            targetPos += new Vector3(1, 0, 0) * distance;
        }

        //回転
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }

        MovePlyer(targetPos);


        //画面外判定
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
        {
            if (hit.collider.CompareTag("judgment"))
            {
                //targetPos = new Vector3(0, 0, 0) * distance;
                targetPos = new Vector3(old.transform.position.x, old.transform.position.y, -0.5f);
            }
        }


        //場所を選ぶ
        if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Destroy(Pice);
                targetPos = new Vector3(0.0f, 0.0f, -0.5f);
                //this.gameObject.transform.position = new Vector3(0,0,-0.5f);
                activePiece = spawner.SpawnPiece(this.gameObject);
                Pice = activePiece.gameObject;

            }
        }
    }


    private void MovePlyer(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }
}

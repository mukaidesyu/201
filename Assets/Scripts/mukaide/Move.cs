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

    public int feald = 0;

    public int putNo = 1;

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

        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>(); // 右
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>(); // 上
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>(); // 下
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>(); // 左
    }

    void Update()
    {
        RaycastHit hit;

        //移動
        if (Input.GetKey(KeyCode.W)||Input.GetAxis("Vertical") >= 1.0f)
        {
            Debug.Log(Input.GetAxis("Vertical"));
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            this.transform.position += new Vector3(0, 0, 0.05f);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") <= -1.0f)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            this.transform.position += new Vector3(0, 0, -0.05f);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") <= -1.0f)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            this.transform.position += new Vector3(-0.05f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") >= 1.0f)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                {
                    old = hit.collider.gameObject;
                }
            }
            this.transform.position += new Vector3(0.05f, 0, 0);
        }

        //回転
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 4"))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 5"))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }

        //場所を選ぶ
        if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // ピースを置くとここに入る
                if(Pice.GetComponent<Piece>().flagp() == true) // 現状Pフラグが立ってない
                {
                    Destroy(Pice);
                    targetPos = new Vector3(0.0f, 0.1f, 0.0f);
                    //this.gameObject.transform.position = new Vector3(0,0,-0.5f);
                    activePiece = spawner.SpawnPiece(this.gameObject);
                    Pice = activePiece.gameObject;


                    // ここで渡すピースを判定する
                    tile tileScript = GameObject.Find("Tile").GetComponent<tile>();
                    GameObject onTile = tileScript.GetOnTile();
                    GameObject farTile = tileScript.GetFarTile(onTile);
                    
                    // 猫に渡す
                    Neko_NavMesh nekoScript = GameObject.Find("Neko").GetComponent<Neko_NavMesh>();
                    nekoScript.SetTarget(onTile);
                    nekoScript.SetNextTarget(farTile);


                    // 全フラグ下げる
                    tileScript.EndNowPut();
                }
            }
        }
    }


    private void MovePlyer(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //ベイク
        GameObject.Find("NavMeshSurface").GetComponent<NavMesh_Surface>().Bake();
    }
}

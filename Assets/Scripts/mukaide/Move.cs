using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    private float distance = 1.0f;
    public int move = 2;
    public bool putflag = true;

    private Vector3 targetPos;
    private Vector3 oldPos;

    bool rot = true;

    public float Rtspeed = 3.0f;

    Spawner spawner;    // スポナー
    Piece activePiece;  // 生成されたピース 
    GameObject Pice;

    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;

    public int feald = 0;

    public int putNo = 1;

    public bool Unpossible = true;//操作不能フラグ
    public float UnpossibleTimer = 0;//操作不能タイマー

    //SE
    SEenter se;

    private void Start()
    {

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

        se = GameObject.Find("playerSE").GetComponent<SEenter>();

        targetPos = transform.position;
        oldPos = transform.position;
    }

    void Update()
    {

        //移動
        if (Input.GetAxis("Vertical") >= 0.3f && transform.position == targetPos)
        {
            oldPos = transform.position;
            targetPos += new Vector3(0, 0, move) * distance;
            //this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") <= -0.3f && transform.position == targetPos)
        {
            oldPos = transform.position;
            targetPos += new Vector3(0, 0, -move) * distance;
            //this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") <= -0.3f && transform.position == targetPos)
        {
            oldPos = transform.position;
            targetPos += new Vector3(-move, 0, 0) * distance;
            // this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") >= 0.3f && transform.position == targetPos)
        {
            oldPos = transform.position;
            targetPos += new Vector3(move, 0, 0) * distance;
            //this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
        }

        //回転
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 4"))
        {
            rot = false;
            StartCoroutine(rt());
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 5"))
        {
            rot = false;
            StartCoroutine(rt2());
        }

        //操作可能か判断
        if (Unpossible == true)
        {
            //場所を選ぶ
            if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    // ピースを置くとここに入る
                    if (Pice.GetComponent<Piece>().flagp() == true) // 現状Pフラグが立ってない
                    {
                        se.EnterSE();

                        Destroy(Pice);
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

                        //操作不能時間のフラグ
                        Unpossible = false;
                        UnpossibleTimer = 1.0f;
                    }
                }
            }
        }

       //if (tilemanager.PutFlag() == false || tilemanager1.PutFlag1() == false || tilemanager2.PutFlag2() == false || tilemanager3.PutFlag3() == false&& transform.position == targetPos)
       //{
       //    targetPos = oldPos * distance;
       //}
     
        if (tilemanager.PutFlag() == false)
        {
            targetPos -= new Vector3(-move, 0, 0) * distance;
            //this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
        }
        if (tilemanager1.PutFlag1() == false)
        {
            oldPos = transform.position;
            targetPos -= new Vector3(0, 0, move) * distance;
            //this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
        }
        if (tilemanager2.PutFlag2() == false)
        {
            oldPos = transform.position;
            targetPos -= new Vector3(0, 0, -move) * distance;
            // this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
        }
        if (tilemanager3.PutFlag3() == false)
        {
            targetPos -= new Vector3(move, 0, 0) * distance;
            //this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
        }

        MovePlyer(targetPos);

        if (Unpossible == false)
        {
            UnpossibleTimerCount();
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

    public void UnpossibleTimerCount()
    {
        UnpossibleTimer -= Time.deltaTime;
        if(UnpossibleTimer <= 0)
        {
            Unpossible = true;
        }
    }

    public bool GetUnpossible()
    {
        return Unpossible;
    }

    IEnumerator rt()
    {
        float i = 0;
        while (i < 90/ Rtspeed)
        {
            i++;
            this.transform.Rotate(0, 0, Rtspeed /* Time.deltaTime*/ );
            yield return null;
        }
        rot = true;
    }
 
    IEnumerator rt2()
    {
        float i = 0;
        while (i > -90 / Rtspeed)
        {
            i--;
            this.transform.Rotate(0, 0, -Rtspeed /* Time.deltaTime */);
            yield return null;
        }
        rot = true;
    }
}

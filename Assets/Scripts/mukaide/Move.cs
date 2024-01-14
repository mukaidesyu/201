using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    private float distance = 1.0f;
    public int move = 2;
    public bool putflag = true;

    private Vector3 targetPos;

    public  bool rot = true;

    public float Rtspeed = 3.0f;

    Spawner spawner;    // スポナー
    Piece activePiece;  // 生成されたピース 
    GameObject Pice;

    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;
    TurnScript turnScript;

    public int feald = 0;

    public int putNo = 1;

    public bool Unpossible = true;//操作不能フラグ
    public float UnpossibleTimer = 0;//操作不能タイマー

    public bool Hit = true;//操作不能フラグ
    public float HitsTimer = 0;//操作不能タイマー

    // チュートリアルかどうか
    string sceneName;
    TutorialData tutorialData;
    bool tutorialBool = true;
    bool tutorialFirst = true;

    //SE
    AudioSource audio;
    AudioClip clip1;
    AudioClip clip2;

    Live2D.Cubism.Framework.Expression.CubismExpressionController face;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        // スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();

        tutorialFirst = false;
        // もしチュートリアルシーンだったら、チュートリアル
        if (sceneName == "tutorial")
        {
            if (!activePiece)
            {
                // チュートリアルの最初のピースは決まったピース
                activePiece = spawner.SpawnPiece(this.gameObject,1);
                Pice = activePiece.gameObject;
            }
            tutorialData = GameObject.Find("TutorialState").GetComponent<TutorialData>();
            tutorialBool = false;
            tutorialFirst = true;
        }
        else // 他のシーン
        {
            if (!activePiece)
            {
                activePiece = spawner.SpawnPiece(this.gameObject);
                Pice = activePiece.gameObject;
            }
            tutorialBool = true;
        }

        turnScript = GameObject.Find("TurnNumber").GetComponent<TurnScript>();

        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>(); // 右
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>(); // 上
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>(); // 下
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>(); // 左

        targetPos = transform.position;

        audio = GetComponent<AudioSource>();
        clip1 = Resources.Load<AudioClip>("SE/mahou");
        clip2 = Resources.Load<AudioClip>("SE/maou_se_onepoint33");

        face = GameObject.Find("ririachan2").GetComponent<Live2D.Cubism.Framework.Expression.CubismExpressionController>();

    }

    void Update()
    {
        bool isMove = true;
        if (sceneName == "tutorial")
        {
            isMove = tutorialData.GetIsMove();
        }
        if (isMove == true)
        {
            //移動
            if (Input.GetAxis("Vertical") >= 0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(0, 0, move) * distance;
                //this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") <= -0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(0, 0, -move) * distance;
                //this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(-move, 0, 0) * distance;
                // this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") >= 0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(move, 0, 0) * distance;
                //this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
            }

            MovePlyer(targetPos);

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
        }

        //画面外判定
        if (tilemanager.PutFlag() == false && transform.position == targetPos)
        {
            Debug.Log("a");
            targetPos -= new Vector3(-move, 0, 0) * distance;

            //this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
        }
        if (tilemanager1.PutFlag1() == false && transform.position == targetPos)
        {
            Debug.Log("b");
            targetPos -= new Vector3(0, 0, move) * distance;

            //this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
        }
        if (tilemanager2.PutFlag2() == false && transform.position == targetPos)
        {
            Debug.Log("c");
            targetPos -= new Vector3(0, 0, -move) * distance;
  
            // this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
        }
        if (tilemanager3.PutFlag3() == false && transform.position == targetPos)
        {
            Debug.Log("d");
            targetPos -= new Vector3(move, 0, 0) * distance;

            //this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
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
                    if (Pice.GetComponent<Piece>().flagp() == true && Pice.GetComponent<Piece>().flage() == false && rot == true) // 現状Pフラグが立ってない
                    {

                        // ここで渡すピースを判定する
                        tile tileScript = GameObject.Find("Tile").GetComponent<tile>();
                        GameObject onTile = tileScript.GetOnTile();
                        GameObject farTile = tileScript.GetFarTile(onTile);

                        if (isMove)
                        {
                            //Debug.Log("ムーブ");
                            audio.clip = clip1;
                            audio.PlayOneShot(audio.clip);
                            Destroy(Pice);
                            //this.gameObject.transform.position = new Vector3(0,0,-0.5f);
                            if (tutorialFirst == true)
                            {
                                activePiece = spawner.SpawnPiece(this.gameObject, 1);
                                tutorialFirst = false;
                            }
                            else
                            {
                                activePiece = spawner.SpawnPiece(this.gameObject);
                            }
                            Pice = activePiece.gameObject;


                            // 猫に渡す
                            Neko_NavMesh nekoScript = GameObject.Find("Neko").GetComponent<Neko_NavMesh>();
                            nekoScript.SetTarget(onTile);
                            nekoScript.SetNextTarget(farTile);
                            nekoScript.SetNyanFlag(false);

                            // ターンを1ターン経過させる
                            turnScript.TurnPlus();

                            // 全フラグ下げる
                            tileScript.EndNowPut();

                            //操作不能時間のフラグ
                            Unpossible = false;
                            UnpossibleTimer = 1.0f;
                        }
                        
                    }
                    else
                    {
                        if (isMove)
                        {
                            audio.clip = clip2;
                            audio.PlayOneShot(audio.clip);
                            face.FaceChange(2);
                        }
                    }
                }
            }
        }

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

    public bool Rotflag()
    {
        return rot;
    }

}

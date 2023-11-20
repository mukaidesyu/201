using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public GameObject[] point;

    // ポジション類
    private Vector3 targetPos;

    // 移動量
    private Vector3 moveDir;


    public int NowStage;
    public bool Go;
    public float ChangeTime = 0.4f;
    public AudioClip clip;
    private AudioSource audio;

    [SerializeField]private bool isInput;
    private StageNo stageNo;
    void Start()
    {
        NowStage = 1;
        isInput = true;
        stageNo = GameObject.Find("NO").GetComponent<StageNo>();
        Go = false;
        audio = this.GetComponent<AudioSource>();
    }


    void Update()
    {
        bool isRun = false;

        if (isInput == false)
        {
            isRun = true;
            this.transform.position += moveDir.normalized * Time.deltaTime * 3.0f;
            if(moveDir.x > 0)
            {
                transform.eulerAngles = new Vector3 (0,90,0); 
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            if (Vector3.Distance(transform.position, targetPos) <= 0.06)
            {
                transform.position = targetPos;
                transform.eulerAngles = new Vector3(0, 180, 0);
                isInput = true;
            }
        }

        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsRun", isRun);

        // 移動中じゃない時
        if (isInput)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GoToNextStage(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GoToNextStage(1);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Go = true;

            }
        }

        if (Go)
        {
            ChangeTime -= Time.deltaTime;
            if (ChangeTime < 0.0f)
            {
                audio.PlayOneShot(clip);
                switch (NowStage)
                {
                    case 1:
                        GameObject.Find("Main Camera").GetComponent<SceneController>().sceneChange("Game");
                        break;
                    case 2:
                        GameObject.Find("Main Camera").GetComponent<SceneController>().sceneChange("Game");
                        break;
                    case 3:
                        GameObject.Find("Main Camera").GetComponent<SceneController>().sceneChange("Game");
                        break;
                    case 4:
                        GameObject.Find("Main Camera").GetComponent<SceneController>().sceneChange("Game");
                        break;
                }
            }
        }
    }

    void FixedUpdate()
    {

    }

    void GoToNextStage(int n)
    {
        if (isInput == false) return;

        // 変更する
        NowStage = NowStage + n;
        if(NowStage < 1)
        {
            NowStage = 1;
            return;
        }
        if (NowStage > 4)
        {
            NowStage = 4;
            return;
        }

        // 目標地点を設定
        targetPos = point[NowStage - 1].transform.position;
        moveDir = point[NowStage-1].transform.position - this.transform.position;
        moveDir = moveDir.normalized ;

        //  ステージ表示を更新する
        stageNo.no = NowStage;
        isInput = false;
    }
}

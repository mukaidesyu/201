using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Neko_NavMesh : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform nextTarget;
    private NavMeshAgent m_Agent;
    private GameObject goalPanel;
    Animator animator;
    bool isRun;
    public float FastSpeed;
    float speed;

    void Start()
    {
        target = this.transform;
        nextTarget = null;
        m_Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isRun = false;
        speed = 1.0f;
    }

    void Update()
    {
        isRun = true;
        // ゴールのパネルが歩ける状態のときは優先的にゴールに向かう
        if (goalPanel.GetComponent<Tilemanager>().PutWalkFlag())
        {
            target = goalPanel.transform;
            nextTarget = null;

            // ゴール判定
            if ( Vector3.Distance(this.transform.position, target.position) < 0.5)
            {
                isRun = false;
                GameObject.Find("CanvasManager").GetComponent<CanvasManagerScript>().SetClear(true);
            }
        }
        else if (nextTarget != null && Vector3.Distance(this.transform.position, target.transform.position) < 0.5)
        {
            target = nextTarget;
            nextTarget = null;
        }
        else if(nextTarget == null && Vector3.Distance(this.transform.position, target.transform.position) < 0.5)
        {
            isRun = false;
        }


        m_Agent.speed = speed;
        // 早送りボタン
        if (Input.GetKey(KeyCode.F) || (Input.GetAxis("TriggerLR") > 0))
        {
            m_Agent.speed = FastSpeed;
        }

        m_Agent.SetDestination(target.position); // 移動処理

        animator.SetBool("IsRun", isRun); // アニメーション処理

        // デバッグ用ゴールモード****************************************
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject.Find("CanvasManager").GetComponent<CanvasManagerScript>().SetClear(true);
        }
    }

    // ターゲットセット
    public void SetTarget(GameObject _target)
    {
        target = _target.transform;
    }
    public void SetNextTarget(GameObject _next)
    {
        nextTarget = _next.transform;
    }

    public void SetGoal(GameObject _goal)
    {
        goalPanel = _goal;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Neko_NavMesh : MonoBehaviour
{
    
    private Transform target;
    private Transform nextTarget;
    private NavMeshAgent m_Agent;
    [SerializeField] private GameObject goalPanel;

    // ターゲットにする物のリスト


    void Start()
    {
        target = this.transform;
        nextTarget = null;
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ゴールのパネルが歩ける状態のときは優先的にゴールに向かう
        if (goalPanel.GetComponent<Tilemanager>().PutWalkFlag())
        {
            target = goalPanel.transform;
            nextTarget = null;
        }
        else if(nextTarget != null && Vector3.Distance(this.transform.position, target.transform.position) < 1)
        {
            target = nextTarget;
            nextTarget = null;
        }
        m_Agent.SetDestination(target.position); // 移動処理


        // ゴール判定
        if (Vector3.Distance(this.transform.position, target.position) < 1.0)
        {
            SceneManager.LoadScene("StartScene");
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

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

    // �^�[�Q�b�g�ɂ��镨�̃��X�g


    void Start()
    {
        target = this.transform;
        nextTarget = null;
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // �S�[���̃p�l�����������Ԃ̂Ƃ��͗D��I�ɃS�[���Ɍ�����
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
        m_Agent.SetDestination(target.position); // �ړ�����


        // �S�[������
        if (Vector3.Distance(this.transform.position, target.position) < 1.0)
        {
            SceneManager.LoadScene("StartScene");
        }

    }

    // �^�[�Q�b�g�Z�b�g
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

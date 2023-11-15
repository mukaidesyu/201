using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Neko_NavMesh : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Transform nextTarget;
    private NavMeshAgent m_Agent;

    // �^�[�Q�b�g�ɂ��镨�̃��X�g


    void Start()
    {
        target = this.transform;
        nextTarget = null;
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        m_Agent.SetDestination(target.position);
        if(nextTarget != null && Vector3.Distance(this.transform.position, target.transform.position) < 1)
        {
            target = nextTarget;
            nextTarget = null;
        }


        if (Vector3.Distance(this.transform.position, target.position) < 1.0)
        {
            //SceneManager.LoadScene("StartScene");
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
}

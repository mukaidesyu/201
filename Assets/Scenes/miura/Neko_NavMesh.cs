using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Neko_NavMesh : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;
    private NavMeshAgent m_Agent;



    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        m_Agent.SetDestination(m_Target.position);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NekoOff : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Neko_NavMesh Neko_NavMeshScript;
    NekoRay NekoRayScript;
    Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Neko_NavMeshScript = GetComponent<Neko_NavMesh>();
        NekoRayScript= GetComponent<NekoRay>();
        terrain = GetComponent<Terrain>();
    }

    public void NekoStop()
    {
        anim.enabled = false;
        Neko_NavMeshScript.enabled = false;
        NekoRayScript.enabled = false;
        terrain.enabled = false;
        agent.enabled = false;
    }
}

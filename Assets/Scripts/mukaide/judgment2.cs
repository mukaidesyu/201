using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgment2 : MonoBehaviour
{
    public bool putflag2 = true;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        putflag2 = false;
    }

    void OnCollisionExit(Collision collision)
    {
        putflag2 = true;
    }

    public bool PutFlag2()
    {
        return putflag2;
    }
}

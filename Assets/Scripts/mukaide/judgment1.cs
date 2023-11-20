using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgment1 : MonoBehaviour
{
    public bool putflag1 = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        putflag1 = false;
    }

    void OnCollisionExit(Collision collision)
    {
        putflag1= true;
    }

    public bool PutFlag1()
    {
        return putflag1;
    }
}

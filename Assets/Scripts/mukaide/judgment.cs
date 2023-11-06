using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgment : MonoBehaviour
{
    public bool putflag = true;

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
        putflag = false;
    }

    void OnCollisionExit(Collision collision)
    {
        putflag = true;
    }

    public bool PutFlag()
    {
        return putflag;
    }
}

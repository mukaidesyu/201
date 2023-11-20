using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgment3 : MonoBehaviour
{
    public bool putflag3 = true;

    // Start is called before the first frame update
    void Start()
    {

        this.gameObject.transform.position = new Vector3(-0f, 1.2f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        putflag3 = false;
    }

    void OnCollisionExit(Collision collision)
    {
        putflag3 = true;
    }

    public bool PutFlag3()
    {
        return putflag3;
    }
}

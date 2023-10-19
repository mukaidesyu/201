using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour
{
    public bool walkflag = false;
    private int TileNo = 0;

    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<Renderer>().material.color = Color.red;
        TileNo++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(walkflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void WalkFlag()
    {
        walkflag = true;
    }
}

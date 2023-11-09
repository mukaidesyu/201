using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour, Clickable
{
    public bool walkflag = false;

    private int TileNo = 0;

    public void WalkFlag()
    {
        // ÉNÉäÉbÉNÇµÇΩéûÇÃèàóù
        walkflag = true;
    }



    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<Renderer>().material.color = Color.red;
        TileNo++;
    }

    // Update is called once per frame
    void Update()
    {

        if (walkflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public bool PutWalkFlag()
    {
        return walkflag;
    }
}

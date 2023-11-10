using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour, Clickable
{
    public bool walkflag = false;

    public int TileNo;

    public int putno = 0;

    public bool Goalflag = false;

    public void WalkFlag()
    {
        // ÉNÉäÉbÉNÇµÇΩéûÇÃèàóù
        walkflag = true;
    }

    public int PutNo()
    {
        return TileNo;
    }

    public bool PutWalkFlag()
    {
        return walkflag;
    }

    public void Startpanel()
    {
        walkflag = true;
    }

    public void Goalpanel()
    {
        Goalflag = true;
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

        if(Goalflag == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    List<GameObject> pc = new List<GameObject>();
    public bool pflag = false;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < this.transform.childCount; i++)
        {
            pc.Add(transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (pc[i].GetComponent<PieceRay>().pfl() == true)
                {
                    pflag = true;
                }
            }
        }

    }

    public bool flagp()
    {
        return pflag;
    }

    private void FixedUpdate()
    {


    }
}

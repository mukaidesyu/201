using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    List<GameObject> pc = new List<GameObject>();
    public bool pflag = false;
    public bool eflag = false;

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
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
        {
            int i = 0;
            eflag = false;
            for (i = 0; i < this.transform.childCount; i++)
            {
                if (pc[i].GetComponent<PieceRay>().pfl() == true)
                {
                    pflag = true;
                }
                if (pc[i].GetComponent<PieceRay>().Ev() == EventStatus.Ike || pc[i].GetComponent<PieceRay>().Ev() == EventStatus.Rock || pc[i].GetComponent<PieceRay>().Ps() == PanelStatus.Nothing)
                {
                    eflag = true;
                }
            }

        }

    }

    public bool flagp()
    {
        return pflag;
    }

    public bool flage()
    {
        return eflag;
    }

    private void FixedUpdate()
    {


    }
}

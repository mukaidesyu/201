using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Clickable
{
    void WalkFlag();
  //  bool PutFlag();
}


public class PieceRay : MonoBehaviour
{
    List<GameObject> walkpanel = new List<GameObject>();

    public bool putflag = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, 10.0f))
        {
            if (hit.collider.CompareTag("judgment")) putflag = false;
            if (putflag)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Clickable c = hit.collider.gameObject.GetComponent<Clickable>();

                    //c.WalkFlag();
                    Debug.Log("êFïœÇ¶ÇÈ");

                }
            }
            // óŒêFÇ…ïœçXÇ∑ÇÈ
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }


    }


}

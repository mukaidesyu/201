using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Clickable
{
    void WalkFlag();
}


public class PieceRay : MonoBehaviour
{
    List<GameObject> walkpanel = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, 10.0f))
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Clickable c = hit.collider.gameObject.GetComponent<Clickable>();
                c.WalkFlag();
            }

            // óŒêFÇ…ïœçXÇ∑ÇÈ
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }


}

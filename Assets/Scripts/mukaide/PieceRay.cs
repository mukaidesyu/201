using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRay : MonoBehaviour
{
    public bool moveflag = true;

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
            // óŒêFÇ…ïœçXÇ∑ÇÈ
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //Debug.Log("Ç†ÇΩÇ¡ÇƒÇÈ");

        }

    }

}

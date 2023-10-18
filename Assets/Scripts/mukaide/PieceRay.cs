using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, Vector3.forward, Color.red, 10.0f);

        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, 10.0f))
        {
            Debug.Log("Ç†ÇΩÇ¡ÇƒÇÈ");
          
            // ê‘êFÇ…ïœçXÇ∑ÇÈ
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 10.0f))
        {
            Debug.DrawRay(this.transform.position, Vector3.down, Color.red);

            // ‚ ‚½‚Á‚½‚ç
            //if (hit.collider)
            //{

            //}
        }
    }
}

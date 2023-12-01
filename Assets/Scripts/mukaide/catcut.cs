using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catcut : MonoBehaviour
{
    private int move = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z <= 22)
        {
            this.transform.position += new Vector3(0, 0, move) * Time.deltaTime;
        }

    }
}

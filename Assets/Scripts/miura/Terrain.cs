using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの色を赤に変更する
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

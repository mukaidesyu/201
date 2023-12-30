using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Unmask : MonoBehaviour
{
    TutorialData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("TutorialState").GetComponent<TutorialData>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

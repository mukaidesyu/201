using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageNo : MonoBehaviour
{
    public int no; 
    TextMeshProUGUI str;
    void Start()
    {
        no = 1;
        str = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        str.text = no.ToString("0");
    }
}

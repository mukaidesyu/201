using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nameScript : MonoBehaviour
{
    TalkDataScript script;
    TextMeshProUGUI tmPro;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("TalkData").GetComponent<TalkDataScript>();
        tmPro = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string name = script.GetName();
        tmPro.text = name;
    }
}

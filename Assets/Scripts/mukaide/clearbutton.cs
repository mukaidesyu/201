using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearbutton : MonoBehaviour
{
   [SerializeField] Button button1;
    [SerializeField] Button button2;

    private float time = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
 
        time = 5;
        button1 = GameObject.Find("nextbutton").GetComponent<Button>();
        button1.GetComponent<Button>().interactable = false;
        button2 = GameObject.Find("titlebutton").GetComponent<Button>();
        button2.GetComponent<Button>().interactable = false;
        //É{É^ÉìÇ™ëIëÇ≥ÇÍÇΩèÛë‘Ç…Ç»ÇÈ
        button1.Select();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = true;
        }

    }
}

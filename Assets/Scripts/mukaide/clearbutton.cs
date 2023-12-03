using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearbutton : MonoBehaviour
{
   [SerializeField] Button button;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("‚ ‚ ‚ ‚ ‚ ");
        button = GameObject.Find("nextbutton").GetComponent<Button>();
        //ƒ{ƒ^ƒ“‚ª‘I‘ğ‚³‚ê‚½ó‘Ô‚É‚È‚é
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

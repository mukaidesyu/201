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
        Debug.Log("あああああ");
        button = GameObject.Find("nextbutton").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

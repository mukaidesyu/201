using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class Stagesel : MonoBehaviour
{
    Button button;

    TextMeshProUGUI tmp;

   [SerializeField] EventSystem eventsistem;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("マップ　　１").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
        //テキストの変更
        tmp = GameObject.Find("stageno").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        tmp.text = eventsistem.currentSelectedGameObject.name;
    }
}

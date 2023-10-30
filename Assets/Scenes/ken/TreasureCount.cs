using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureCount : MonoBehaviour
{
    public int treasure;
    public int treasuremax;
    GameObject ui;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        treasure = 0;
        treasuremax = 5;
        ui = GameObject.Find("UI_TreasureCount");
        tmp = ui.GetComponent<TextMeshProUGUI>();
        tmp.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (treasure <= treasuremax)
        {
            tmp.text = treasure.ToString("0") + "/" + treasuremax/*ここにステージごとのMAX宝箱数を入れる*/;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TreasurePlus();     //エンターしたら宝箱＋１関数呼び出し
            }
        }
    }
    void TreasurePlus() //宝箱＋１する関数
    {
        treasure++;
    }
   
}

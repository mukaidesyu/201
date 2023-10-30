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
        treasuremax = 0;
        ui = GameObject.Find("UI_TreasureCount");
        tmp = ui.GetComponent<TextMeshProUGUI>();
        tmp.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        MaxTreasure();
        if (treasure <= treasuremax)
        {
            tmp.text = treasure.ToString("0") + "/" + treasuremax/*‚±‚±‚ÉƒXƒe[ƒW‚²‚Æ‚ÌMAX•ó” ”‚ð“ü‚ê‚é*/;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TreasurePlus();     //ƒGƒ“ƒ^[‚µ‚½‚ç•ó” {‚PŠÖ”ŒÄ‚Ño‚µ
            }
        }
    }
    void TreasurePlus() //•ó” {‚P‚·‚éŠÖ”
    {
        treasure++;
    }

    void MaxTreasure()//•ó” ‚ÌÅ‘å”
    {
        treasuremax = 5;
    }
   
}

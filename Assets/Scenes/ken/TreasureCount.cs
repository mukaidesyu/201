using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureCount : MonoBehaviour
{
    public int treasure = 0;
    GameObject ui;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        treasure = 0;
        ui = GameObject.Find("UI_TreasureCount");
        tmp = ui.GetComponent<TextMeshProUGUI>();
        tmp.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = treasure.ToString("0") + "/" + 5/*�����ɃX�e�[�W���Ƃ�MAX�󔠐�������*/;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TreasurePlus();     //�G���^�[������󔠁{�P�֐��Ăяo��
        }
    }
    void TreasurePlus() //�󔠁{�P����֐�
    {
        treasure++;
    }

   
}

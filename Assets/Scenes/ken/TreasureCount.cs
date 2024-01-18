using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureCount : MonoBehaviour
{
    public int treasure;
    [SerializeField]
    public int treasuremax;
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
        if (treasure <= treasuremax)
        {
            tmp.text = treasure.ToString("0") + "/" + treasuremax/*�����ɃX�e�[�W���Ƃ�MAX�󔠐�������*/;
        }
    }
    public void TreasurePlus() //�󔠁{�P����֐�
    {
        treasure++;
    }
   
    public int GetTreasureCount() 
    {
        return treasure;
    }
}

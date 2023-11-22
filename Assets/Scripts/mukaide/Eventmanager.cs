using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventmanager : MonoBehaviour
{
    TreasureCount treasure;

    //猫ちゃんに呼んでほしい関数(タイルのイベントフラグが立ってたのをとったら)
    //今からいろんな動き追加していくから待っててほしいとりあえずで作った
    public void Event()
    {
        treasure.TreasurePlus();
    }

    // Start is called before the first frame update
    void Start()
    {
        treasure = GameObject.Find("UI_TreasureCount").GetComponent<TreasureCount>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("足し算！");
            Event();
        }
    }

}

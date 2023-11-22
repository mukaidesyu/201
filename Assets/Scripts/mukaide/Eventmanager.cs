using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventmanager : MonoBehaviour
{
    TreasureCount treasure;

    //猫ちゃんに呼んでほしい関数(タイルのイベントフラグが立ってたのをとったら)
    //今からいろんな動き追加していくから待っててほしいとりあえずで作った
    public void Event(GameObject eventTile) // 引数イベントの種類
    {
        Tilemanager script = eventTile.GetComponent<Tilemanager>();
        switch (script.GetEvent())// イベント内容をスイッチしそう
        {
            case EventStatus.Juel:
            treasure.TreasurePlus();
            // ここに演出的な処理入れる、、、？

            script.SetEvent(EventStatus.Juel_Got);
                break;
        }
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
        }
    }

}

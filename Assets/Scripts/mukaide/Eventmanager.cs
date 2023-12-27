using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventmanager : MonoBehaviour
{
    public GameObject[] MemoUI;
    TreasureCount treasure;

    ItemgetUI itemUI;
    Live2D.Cubism.Framework.Expression.CubismExpressionController face;

    //猫ちゃんに呼んでほしい関数(タイルのイベントフラグが立ってたのをとったら)
    //今からいろんな動き追加していくから待っててほしいとりあえずで作った
    public void Event(GameObject eventTile) // 引数イベントの種類
    {
        Tilemanager script = eventTile.GetComponent<Tilemanager>();
        switch (script.GetEvent())// イベント内容をスイッチしそう
        {
            case EventStatus.Kinoko:
                // ここに演出的な処理
                itemUI.SwitchItemGetStart(0);
                face.FaceChange(1);
                // 取得状態に変更
                MemoUI[0].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kinoko_Got);
                break;

            case EventStatus.Sakana:
                // ここに演出的な処理
                itemUI.SwitchItemGetStart(1);
                face.FaceChange(1);
                MemoUI[1].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Sakana_Got);
                break;
            case EventStatus.Kari1:
                treasure.TreasurePlus();
                // ここに演出的な処理
                itemUI.SwitchItemGetStart(2);
                face.FaceChange(1);
                MemoUI[2].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari1_Got);
                break;

            case EventStatus.Kari2:
                // ここに演出的な処理
                itemUI.SwitchItemGetStart(3);
                face.FaceChange(1);
                MemoUI[3].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari2_Got);
                break;
            case EventStatus.Kari3:
                // ここに演出的な処理
                itemUI.SwitchItemGetStart(4);
                face.FaceChange(1);
                MemoUI[4].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari3_Got);
                break;

            case EventStatus.Zasso:
                // ここに演出的な処理
                script.SetEvent(EventStatus.Zasso_Got); // 雑草を消す
                break;
                // どんどこどんどんここにアイテムの処理追加
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        treasure = GameObject.Find("UI_TreasureCount").GetComponent<TreasureCount>();
        itemUI = GameObject.Find("ItemGet").GetComponent<ItemgetUI>();
        face = GameObject.Find("ririachan2").GetComponent<Live2D.Cubism.Framework.Expression.CubismExpressionController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}

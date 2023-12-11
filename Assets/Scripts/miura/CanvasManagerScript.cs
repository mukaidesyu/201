using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerScript : MonoBehaviour
{
    bool isClear;
    bool canvasSet;
    GameObject gameCanvas;
    GameObject clearCanvas;
    GameObject nikukyuuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        canvasSet = false;
        gameCanvas = this.transform.GetChild(0).gameObject;
        clearCanvas = this.transform.GetChild(1).gameObject;
        nikukyuuCanvas = this.transform.GetChild(2).gameObject;
        clearCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            if (canvasSet == false)
            {
                DrawClearCanvas();
                GameObject.Find("getitem").GetComponent<GetItemClear>().ClearStart(); // クリア演出開始
                // 下は各種変数をクリア画面に渡したあと
                gameCanvas.SetActive(false);// ゲームキャンバスを消す
                GameObject.Find("Neko").GetComponent<NekoOff>().NekoStop();
                GameObject.Find("GameObject").SetActive(false); // ゲームオブジェクトを消す
                canvasSet = true;

                //NikukyuuState sta = nikukyuuCanvas.GetComponent<NikukyuuManager>().GetNikuFadeState();
                //if (sta == NikukyuuState.vanish)
                //{
                //    DrawClearCanvas();
                //}
                //else if (sta == NikukyuuState.finish)
                //{
                //    Debug.Log("演出開始");
                //    GameObject.Find("getitem").GetComponent<GetItemClear>().ClearStart(); // クリア演出開始
                //    // 下は各種変数をクリア画面に渡したあと
                //    gameCanvas.SetActive(false);// ゲームキャンバスを消す
                //    GameObject.Find("Neko").GetComponent<NekoOff>().NekoStop();
                //    GameObject.Find("GameObject").SetActive(false); // ゲームオブジェクトを消す
                //    canvasSet = true;
                //}
            }
        }
    }

    public void SetClear(bool set)
    {
        if (isClear == true) return;

        isClear = set;
        //nikukyuuCanvas.GetComponent<NikukyuuManager>().NikukyuuFadeStart();
    }

    public void DrawClearCanvas()
    {
        // クリアキャンバスを出す
        clearCanvas.SetActive(true);
        int tmp = GameObject.Find("TurnNumber").GetComponent<TurnScript>().GetTurn();
        GameObject.Find("ClearTurnNumber").GetComponent<ClearTurnScript>().SetTurn(tmp);
    }
}

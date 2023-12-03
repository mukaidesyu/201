using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerScript : MonoBehaviour
{
    bool isClear;
    bool canvasSet;
    GameObject gameCanvas;
    GameObject clearCanvas;
    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        canvasSet = false;
        gameCanvas = this.transform.GetChild(0).gameObject;
        clearCanvas = this.transform.GetChild(1).gameObject;
        clearCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            if (canvasSet == false)
            {
                canvasSet = true;
                DrawClearCanvas();
            }
        }
    }

    public void SetClear(bool set)
    {
        isClear = set;
    }

    public void DrawClearCanvas()
    {
        clearCanvas.SetActive(true);
        GameObject.Find("getitem").GetComponent<GetItemClear>().ClearStart();
        int tmp = GameObject.Find("TurnNumber").GetComponent<TurnScript>().GetTurn();
        GameObject.Find("ClearTurnNumber").GetComponent<ClearTurnScript>().SetTurn(tmp);

        // 下は各種変数をクリア画面に渡したあと
        gameCanvas.SetActive(false);// ゲームキャンバスを消す
        GameObject.Find("Neko").GetComponent<NekoOff>().NekoStop();
        GameObject.Find("GameObject").SetActive(false); // ゲームオブジェクトを消す
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum IrisFade
{
    None = 0,
    FadeIn,
    FadeOut,
}

public class CanvasManagerScript : MonoBehaviour
{
    bool isClear;
    bool canvasSet;
    GameObject gameCanvas;
    GameObject clearCanvas;
    GameObject nikukyuuCanvas;
    GameBGMManager bgm;

    GameObject nekoShot;
    IrisShot2 iris;
    IrisFade fadeState;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GameObject.Find("Main Camera").GetComponent<GameBGMManager>();
        isClear = false;
        canvasSet = false;
        gameCanvas = this.transform.GetChild(0).gameObject;
        clearCanvas = this.transform.GetChild(1).gameObject;
        nikukyuuCanvas = this.transform.GetChild(2).gameObject;
        clearCanvas.SetActive(false);

        // アリスインフェードを非アクティブに
        GameObject unmask = GameObject.Find("Unmask");
        iris = unmask.GetComponent<IrisShot2>();
        nekoShot = GameObject.Find("NekoShot");
        nekoShot.SetActive(false);

        // フェードの状態を初期化
        fadeState = IrisFade.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            if (canvasSet == false)
            {
                // 真っ暗になったあとの処理 一回通る
                DrawClearCanvas();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            iris.IrisIn();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            iris.IrisOut();
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
        // フェード中は処理しない
        if (iris.GetIsFade() == true) return;

        switch (fadeState)
        {
            case IrisFade.None:
                // クリア開始時一回目なら
                nekoShot.SetActive(true);
                iris.IrisOut();
                fadeState = IrisFade.FadeOut;
                break;

            case IrisFade.FadeOut:
                // クリアキャンバスを出す
                clearCanvas.SetActive(true);
                int tmp = GameObject.Find("TurnNumber").GetComponent<TurnScript>().GetTurn();
                GameObject.Find("ClearTurnNumber").GetComponent<ClearTurnScript>().SetTurn(tmp);
                // 音変える
                bgm.StartBGM();
                // インして状態変更
                iris.IrisIn();
                Debug.Log("いん");
                fadeState = IrisFade.FadeIn;
                break;

            case IrisFade.FadeIn:
                // クリア演出開始
                GameObject.Find("getitem").GetComponent<GetItemClear>().ClearStart();
                // 下は各種変数をクリア画面に渡したあと
                gameCanvas.SetActive(false);// ゲームキャンバスを消す
                GameObject.Find("Neko").GetComponent<NekoOff>().NekoStop();
                GameObject.Find("GameObject").SetActive(false); // ゲームオブジェクトを消す
                // フェード状態の後片付け
                fadeState = IrisFade.None;
                // クリア状態に変更する
                canvasSet = true;
                break;
        }
    }
}

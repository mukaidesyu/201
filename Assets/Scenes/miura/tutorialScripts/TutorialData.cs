using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialState
{
    FirstKaiwa = 0,
    Play1,
    Play2,
    Play3,
    Play4,
    Play5,
    Play6,
    Play7,
    Play8,
}

public class TutorialData : MonoBehaviour
{
    public TutorialState state = TutorialState.FirstKaiwa;


    GameObject talkCanvas;
    // 会話シーンのオブジェクト
    GameObject riria;
    GameObject kuro;
    GameObject Waku;
    GameObject NameWaku;
    GameObject Tutorial2Canvas;
    GameObject Tutorial3Canvas;
    GameObject Tutorial4Canvas;
    GameObject Tutorial5Canvas;

    TalkDataScript talkData;
    [SerializeField] Scenarios scenarios;

    bool BOOL; // 汎用

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //state = TutorialState.FirstKaiwa;
        talkCanvas = GameObject.Find("TalkCanvas");
        Tutorial2Canvas = GameObject.Find("TalkCanvas2");
        Tutorial3Canvas = GameObject.Find("TalkCanvas3");
        Tutorial4Canvas = GameObject.Find("TalkCanvas4");
        Tutorial5Canvas = GameObject.Find("TalkCanvas5");
        talkCanvas.SetActive(true);
        Tutorial2Canvas.SetActive(false);
        Tutorial3Canvas.SetActive(false);
        Tutorial4Canvas.SetActive(false);
        Tutorial5Canvas.SetActive(false);
        riria = GameObject.Find("riria");
        kuro = GameObject.Find("kuro");
        Waku = GameObject.Find("Waku");
        NameWaku = GameObject.Find("Waku_Name");
        talkData = GameObject.Find("TalkData").GetComponent<TalkDataScript>();
        scenarios = GetComponent<Scenarios>();

        BOOL = false;

        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (BOOL == true) return;

        // 現状、会話シーン無い時ここで制御
        switch (state)
        {
            case TutorialState.Play2:
                Invoke("TutorialNext", 1.0f);
                BOOL = true;
                break;
            case TutorialState.Play3:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play4:
                GameObject guide = GameObject.Find("tutorialGuide");

                float dis =  Vector3.Distance(Player.transform.position,guide.transform.position);

                if (dis <= 0.2f)
                {
                    BOOL = true;
                    TutorialNext();
                }
                break;
            case TutorialState.Play5:
                if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    BOOL = true;
                    TutorialBack();
                }

                
                //BOOL = true;


                break;
        }
    }

    public void TutorialNext()
    {
        state = (TutorialState)((int)state + 1);

        // ここで次の状態をセット
        switch (state)
        {
            case TutorialState.Play1:
                riria.SetActive(false);
                kuro.SetActive(false);
                NameWaku.SetActive(false);              
                talkData.SetScenario(scenarios.scenario02);
                break;
            case TutorialState.Play2:
                talkCanvas.SetActive(false);
                Tutorial2Canvas.SetActive(true);
                break;
            case TutorialState.Play3:
                Tutorial2Canvas.SetActive(false);
                Tutorial3Canvas.SetActive(true);
                break;
            case TutorialState.Play4:
                Tutorial3Canvas.SetActive(false);
                Tutorial4Canvas.SetActive(true);
                break;
            case TutorialState.Play5:
                Tutorial4Canvas.SetActive(false);
                Tutorial5Canvas.SetActive(true);
                break;
        }

        BOOL = false;
    }

    public void TutorialBack()
    {
        if (state == TutorialState.Play1)return;

        state = (TutorialState)((int)state - 1);
        // ここで次の状態をセット
        switch (state)
        {
            case TutorialState.Play1:
                riria.SetActive(false);
                kuro.SetActive(false);
                NameWaku.SetActive(false);
                talkData.SetScenario(scenarios.scenario02);
                break;
            case TutorialState.Play2:
                talkCanvas.SetActive(false);
                Tutorial2Canvas.SetActive(true);
                break;
            case TutorialState.Play3:
                Tutorial2Canvas.SetActive(false);
                Tutorial3Canvas.SetActive(true);
                break;
            case TutorialState.Play4:
                Tutorial3Canvas.SetActive(false);
                Tutorial4Canvas.SetActive(true);
                break;
            case TutorialState.Play5:
                Tutorial4Canvas.SetActive(false);
                Tutorial5Canvas.SetActive(true);
                break;
        }

        BOOL = false;
    }
}

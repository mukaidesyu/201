using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialState
{
    FirstKaiwa = 0,
    Play1,
    Play2,
    Play3
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

    TalkDataScript talkData;
    [SerializeField] Scenarios scenarios;
    

    // Start is called before the first frame update
    void Start()
    {
        //state = TutorialState.FirstKaiwa;
        talkCanvas = GameObject.Find("TalkCanvas");
        Tutorial2Canvas = GameObject.Find("TalkCanvas2");
        Tutorial3Canvas = GameObject.Find("TalkCanvas3");
        talkCanvas.SetActive(true);
        Tutorial2Canvas.SetActive(false);
        Tutorial3Canvas.SetActive(false);
        riria = GameObject.Find("riria");
        kuro = GameObject.Find("kuro");
        Waku = GameObject.Find("Waku");
        NameWaku = GameObject.Find("Waku_Name");
        talkData = GameObject.Find("TalkData").GetComponent<TalkDataScript>();
        scenarios = GetComponent<Scenarios>();
    }

    // Update is called once per frame
    void Update()
    {
        // 現状、会話シーン無い時ここで制御
        switch (state)
        {
            case TutorialState.Play2:
                    TutorialNext();
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
                talkCanvas.SetActive(false);
                Tutorial2Canvas.SetActive(false);
                Tutorial3Canvas.SetActive(true);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialState
{
    Play0 = 0,
    Play1,
    Play2,
    Play3,
    Play4,
    Play5,
    Play6,
    Play7,
    Play8,
    Play9,
    Play10,
    Play11,
    Play12,
    Play13,
    Play14,
    Play15,
    Play16,
    Play17,
    Play18,
    Play19,
    Play20,
    Play21,
    Play22,
    Play23,
}

public class TutorialData : MonoBehaviour
{
    public TutorialState state = TutorialState.Play0;


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
    GameObject Tutorial7Canvas;
    GameObject Tutorial8Canvas;
    GameObject Tutorial9Canvas;
    GameObject Tutorial10Canvas;
    GameObject Tutorial11Canvas;
    GameObject Tutorial13Canvas;
    GameObject Tutorial14Canvas;
    GameObject Tutorial15Canvas;
    GameObject Tutorial16Canvas;
    GameObject Tutorial17Canvas;
    GameObject Tutorial18Canvas;
    GameObject Tutorial19Canvas;
    GameObject Tutorial20Canvas;
    GameObject Tutorial21Canvas;
    GameObject Tutorial22Canvas;
    GameObject Tutorial23Canvas;

    TalkDataScript talkData;
    Scenarios scenarios;
    bool isMove;

    bool BOOL; // 汎用
    float StickTime = 0.5f;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        StickTime = 0.5f;
        state = TutorialState.Play0;
        talkCanvas = GameObject.Find("TalkCanvas");
        Tutorial2Canvas = GameObject.Find("TalkCanvas2");
        Tutorial3Canvas = GameObject.Find("TalkCanvas3");
        Tutorial4Canvas = GameObject.Find("TalkCanvas4");
        Tutorial5Canvas = GameObject.Find("TalkCanvas5");
        Tutorial7Canvas = GameObject.Find("TalkCanvas7");
        Tutorial8Canvas = GameObject.Find("TalkCanvas8");
        Tutorial9Canvas = GameObject.Find("TalkCanvas9");
        Tutorial10Canvas = GameObject.Find("TalkCanvas10");
        Tutorial11Canvas = GameObject.Find("TalkCanvas11");
        Tutorial13Canvas = GameObject.Find("TalkCanvas13");
        Tutorial14Canvas = GameObject.Find("TalkCanvas14");
        Tutorial15Canvas = GameObject.Find("TalkCanvas15");
        Tutorial16Canvas = GameObject.Find("TalkCanvas16");
        Tutorial17Canvas = GameObject.Find("TalkCanvas17");
        Tutorial18Canvas = GameObject.Find("TalkCanvas18");
        Tutorial19Canvas = GameObject.Find("TalkCanvas19");
        Tutorial20Canvas = GameObject.Find("TalkCanvas20");
        Tutorial21Canvas = GameObject.Find("TalkCanvas21");
        Tutorial22Canvas = GameObject.Find("TalkCanvas22");
        Tutorial23Canvas = GameObject.Find("TalkCanvas23");
        talkCanvas.SetActive(true);
        Tutorial2Canvas.SetActive(false);
        Tutorial3Canvas.SetActive(false);
        Tutorial4Canvas.SetActive(false);
        Tutorial5Canvas.SetActive(false);
        Tutorial7Canvas.SetActive(false);
        Tutorial8Canvas.SetActive(false);
        Tutorial9Canvas.SetActive(false);
        Tutorial10Canvas.SetActive(false);
        Tutorial11Canvas.SetActive(false);
        Tutorial13Canvas.SetActive(false);
        Tutorial14Canvas.SetActive(false);
        Tutorial15Canvas.SetActive(false);
        Tutorial16Canvas.SetActive(false);
        Tutorial17Canvas.SetActive(false);
        Tutorial18Canvas.SetActive(false);
        Tutorial19Canvas.SetActive(false);
        Tutorial20Canvas.SetActive(false);
        Tutorial21Canvas.SetActive(false);
        Tutorial22Canvas.SetActive(false);
        Tutorial23Canvas.SetActive(false);
        riria = GameObject.Find("riria");
        kuro = GameObject.Find("kuro");
        Waku = GameObject.Find("Waku");
        NameWaku = GameObject.Find("Waku_Name");
        talkData = GameObject.Find("TalkData").GetComponent<TalkDataScript>();
        scenarios = GetComponent<Scenarios>();

        BOOL = false;
        isMove = false;

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
                Invoke("TutorialNext", 2.5f);
                BOOL = true;
                break;
            case TutorialState.Play3:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play4:
                GameObject guide = GameObject.Find("tutorialGuide");

                float dis =  Vector3.Distance(Player.transform.position,guide.transform.position);

                if (dis <= 0.1f)
                {
                    BOOL = true;
                    TutorialNext();
                }
                break;
            case TutorialState.Play5:
                if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                   || Input.GetAxis("Vertical") >= 0.3f || Input.GetAxis("Vertical") <= -0.3f || Input.GetAxis("Horizontal") <= -0.3f || Input.GetAxis("Horizontal") >= 0.3f
                    )
                {
                   // BOOL = true;
                    TutorialBack();
                }

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    // ピースレイが置けたら

                    BOOL = true;
                    TutorialNext();
                }
                break;
            case TutorialState.Play6:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play7:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play8:
                Invoke("TutorialNext", 3.0f);
                BOOL = true;
                break;
            case TutorialState.Play9:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play10:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play11:
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    BOOL = true;
                    TutorialNext();
                }
                break;
            case TutorialState.Play12:
                Invoke("TutorialNext", 4.0f);
                BOOL = true;
                break;
            case TutorialState.Play13:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play14:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play15:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play16:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play17:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play18:
                if ((Input.GetAxis("TriggerLR") < 0))
                {
                    if (Input.GetAxis("Horizontal2") > 0.5f || Input.GetAxis("Horizontal2") < -0.5f)
                    {
                        StickTime -= Time.deltaTime;
                        if (StickTime <= 0)
                        {
                            BOOL = true;
                            TutorialNext();
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BOOL = true;
                    TutorialNext();
                }
                break;
            case TutorialState.Play19:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play20:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play21:
                Invoke("TutorialNext", 2.0f);
                BOOL = true;
                break;
            case TutorialState.Play22:
                Invoke("TutorialNext", 4.0f);
                BOOL = true;
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
                isMove = false;
                break;
            case TutorialState.Play2:
                talkCanvas.SetActive(false);
                Tutorial2Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play3:
                Tutorial2Canvas.SetActive(false);
                Tutorial3Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play4:
                Tutorial3Canvas.SetActive(false);
                Tutorial4Canvas.SetActive(true);
                isMove = true;
                break;
            case TutorialState.Play5:
                Tutorial4Canvas.SetActive(false);
                Tutorial5Canvas.SetActive(true);
                isMove = true;
                break;
            case TutorialState.Play6:
                Tutorial5Canvas.SetActive(false);
                isMove = false;
                break;
            case TutorialState.Play7:
                Tutorial7Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play8:
                Tutorial7Canvas.SetActive(false);
                Tutorial8Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play9:
                Tutorial8Canvas.SetActive(false);
                Tutorial9Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play10:
                Tutorial9Canvas.SetActive(false);
                Tutorial10Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play11:
                Tutorial10Canvas.SetActive(false);
                Tutorial11Canvas.SetActive(true);
                isMove = true;
                break;
            case TutorialState.Play12:
                Tutorial11Canvas.SetActive(false);
                isMove = false;
                break;
            case TutorialState.Play13:
                Tutorial13Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play14:
                Tutorial13Canvas.SetActive(false);
                Tutorial14Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play15:
                Tutorial14Canvas.SetActive(false);
                Tutorial15Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play16:
                Tutorial15Canvas.SetActive(false);
                Tutorial16Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play17:
                Tutorial16Canvas.SetActive(false);
                Tutorial17Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play18:
                Tutorial17Canvas.SetActive(false);
                Tutorial18Canvas.SetActive(true);
                break;
            case TutorialState.Play19:
                Tutorial18Canvas.SetActive(false);
                Tutorial19Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play20:
                Tutorial19Canvas.SetActive(false);
                Tutorial20Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play21:
                Tutorial20Canvas.SetActive(false);
                Tutorial21Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play22:
                Tutorial21Canvas.SetActive(false);
                Tutorial22Canvas.SetActive(true);
                isMove = false;
                break;
            case TutorialState.Play23:
                Tutorial22Canvas.SetActive(false);
                Tutorial23Canvas.SetActive(true);
                isMove = true;
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
                Tutorial5Canvas.SetActive(false);
                break;
            case TutorialState.Play5:
                Tutorial4Canvas.SetActive(false);
                Tutorial5Canvas.SetActive(true);
                break;
            case TutorialState.Play6:
                Tutorial5Canvas.SetActive(false);
                break;
            case TutorialState.Play7:
                Tutorial7Canvas.SetActive(true);
                break;
            case TutorialState.Play8:
                Tutorial7Canvas.SetActive(false);
                Tutorial8Canvas.SetActive(true);
                break;
            case TutorialState.Play9:
                Tutorial8Canvas.SetActive(false);
                Tutorial9Canvas.SetActive(true);
                break;
            case TutorialState.Play10:
                Tutorial9Canvas.SetActive(false);
                Tutorial10Canvas.SetActive(true);
                break;
            case TutorialState.Play11:
                Tutorial10Canvas.SetActive(false);
                Tutorial11Canvas.SetActive(true);
                break;
            case TutorialState.Play12:
                Tutorial11Canvas.SetActive(false);
                break;
            case TutorialState.Play13:
                Tutorial13Canvas.SetActive(true);
                break;
            case TutorialState.Play14:
                Tutorial13Canvas.SetActive(false);
                Tutorial14Canvas.SetActive(true);
                break;
            case TutorialState.Play15:
                Tutorial14Canvas.SetActive(false);
                Tutorial15Canvas.SetActive(true);
                break;
            case TutorialState.Play16:
                Tutorial15Canvas.SetActive(false);
                Tutorial16Canvas.SetActive(true);
                break;
            case TutorialState.Play17:
                Tutorial16Canvas.SetActive(false);
                Tutorial17Canvas.SetActive(true);
                break;
            case TutorialState.Play18:
                Tutorial17Canvas.SetActive(false);
                Tutorial18Canvas.SetActive(true);
                break;
            case TutorialState.Play19:
                Tutorial18Canvas.SetActive(false);
                Tutorial19Canvas.SetActive(true);
                break;
            case TutorialState.Play20:
                Tutorial19Canvas.SetActive(false);
                Tutorial20Canvas.SetActive(true);
                break;
            case TutorialState.Play21:
                Tutorial20Canvas.SetActive(false);
                Tutorial21Canvas.SetActive(true);
                break;
            case TutorialState.Play22:
                Tutorial21Canvas.SetActive(false);
                Tutorial22Canvas.SetActive(true);
                break;
            case TutorialState.Play23:
                Tutorial22Canvas.SetActive(false);
                Tutorial23Canvas.SetActive(true);
                break;
        }

        BOOL = false;
    }

    public bool GetIsMove()
    {
        return isMove;
    }
}

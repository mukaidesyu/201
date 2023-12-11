using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NikukyuuState
{
    appear = 0,
    vanish,

    finish
}

public class NikukyuuManager : MonoBehaviour
{
    public float Interval = 0.5f;
    float interval;
    int FinishId;
    GameObject nikukyuu;
    public int NikukyuuMax = 50;
    List<GameObject> nikukyuus = new List<GameObject>();
    bool start;
    NikukyuuState state;
    void Start()
    {
        start = false;
        state = NikukyuuState.appear;
        FinishId = 0;
        nikukyuu = (GameObject)Resources.Load("Nikukyuu");
        interval = Interval;

        for (int i = 0;i < NikukyuuMax; i++)
        {
            GameObject tmp = Instantiate(nikukyuu,this.transform);
            nikukyuus.Add(tmp);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (start == false) return;

        if (state == NikukyuuState.appear)
        {
            // ˆê’èŽžŠÔ‚²‚Æ‚É•\Ž¦‚³‚¹‚é
            Interval -= Time.deltaTime;
            if (Interval <= 0)
            {
                Debug.Log(FinishId);
                nikukyuus[FinishId].GetComponent<FadeNikukyuu>().Appear();
                FinishId++;   
                Interval = interval;
            }

            if (FinishId == NikukyuuMax - 1) state = NikukyuuState.vanish;
        }
        else if(state == NikukyuuState.vanish)
        {
            // ˆê’èŽžŠÔ‚²‚Æ‚É•\Ž¦‚³‚¹‚é
            Interval -= Time.deltaTime;
            if (Interval <= 0)
            {
                nikukyuus[FinishId].GetComponent<FadeNikukyuu>().Vanish();
                FinishId--;
                Interval = interval;
            }

            if (FinishId < 0)
            {
                state = NikukyuuState.finish;
                start = false;
            }
        }
        else if (state == NikukyuuState.finish)
        {
           return;
        }

    }

    public void NikukyuuFadeStart()
    {
        state = NikukyuuState.appear;
        start = true;

        // Å‰‚ÉÅ‰‚Ì“÷‹…‚ð•\Ž¦‚·‚é
        Debug.Log(FinishId);
        nikukyuus[0].GetComponent<FadeNikukyuu>().Appear();
        FinishId++;
    }

    public NikukyuuState GetNikuFadeState()
    {
        return state;
    }
}

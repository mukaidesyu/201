using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NikukyuuManager : MonoBehaviour
{
    enum NikukyuuState
    {
        appear = 0,
        vanish,

        finish
    }

    public float Interval = 0.5f;
    float interval;
    int FinishId;
    GameObject nikukyuu;
    public int NikukyuuMax = 50;
    List<GameObject> nikukyuus = new List<GameObject>();
    NikukyuuState state;
    void Start()
    {
        state = NikukyuuState.appear;
        FinishId = 0;
        nikukyuu = (GameObject)Resources.Load("Nikukyuu");
        interval = Interval;

        for (int i = 0;i < NikukyuuMax; i++)
        {
            GameObject tmp = Instantiate(nikukyuu,this.transform);
            nikukyuus.Add(tmp);
        }

        // Å‰‚ÉÅ‰‚Ì“÷‹…‚ð•\Ž¦‚·‚é
        nikukyuus[0].GetComponent<FadeNikukyuu>().Appear();
        FinishId++;
    }

    // Update is called once per frame
    private void Update()
    {
        if (state == NikukyuuState.appear)
        {
            // ˆê’èŽžŠÔ‚²‚Æ‚É•\Ž¦‚³‚¹‚é
            Interval -= Time.deltaTime;
            if (Interval <= 0)
            {
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

            if (FinishId < 0) state = NikukyuuState.finish;
        }
        else if (state == NikukyuuState.finish)
        {
           return;
        }
    }
}

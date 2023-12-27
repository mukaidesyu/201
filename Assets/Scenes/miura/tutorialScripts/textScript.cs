using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textScript : MonoBehaviour
{
    TalkDataScript script;
    TextMeshProUGUI tmPro;
    string text;
    string textMax;
    float nextMojiTimeMax;
    public float NextMojiTime = 0.05f;
    bool finish;
    int index;
    int indexMax;
    // Start is called before the first frame update
    void Start()
    {
        nextMojiTimeMax = NextMojiTime;
        script = GameObject.Find("TalkData").GetComponent<TalkDataScript>();
        tmPro = this.GetComponent<TextMeshProUGUI>();
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (finish == true) return;

        NextMojiTime -= Time.deltaTime;

        if (NextMojiTime <= 0)
        {
            if (index < indexMax - 1)
            {
                index++;
                NextMojiTime = nextMojiTimeMax;
                text += textMax[index];
            }
            else
            {
                finish = true;
            }
        }

        tmPro.text = text;
    }

    public void SetText(string scenario)
    {
        textMax = scenario;
        // 一文字目を表示
        text = scenario[0].ToString();
        NextMojiTime = nextMojiTimeMax;

        index = 0;
        indexMax = scenario.Length;
        finish = false;
    }
}

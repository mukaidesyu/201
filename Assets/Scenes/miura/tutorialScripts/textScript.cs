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
    public float nextMojiTimeMax = 0.01f;
    float NextMojiTime;
    bool finish;
    int index;
    int indexMax;
    // Start is called before the first frame update
    void Start()
    {
        NextMojiTime = nextMojiTimeMax;
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

        //if (Input.GetKeyUp(KeyCode.Return))
        //{
        //    index = indexMax - 1;
        //    text = textMax;
        //    finish = true;
        //}

        tmPro.text = text;
    }

    public void SetText(string scenario)
    {
        textMax = scenario;
        // ˆê•¶Žš–Ú‚ð•\Ž¦
        text = scenario[0].ToString();
        NextMojiTime = nextMojiTimeMax;

        index = 0;
        indexMax = scenario.Length;
        finish = false;
    }

    public bool GetTextFinish()
    {
        return finish;
    }
}

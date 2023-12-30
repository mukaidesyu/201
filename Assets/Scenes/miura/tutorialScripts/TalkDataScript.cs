using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scenario
{
    public string ID;
    public List<string> Texts;
    public List<string> Names;
    public string NextID;
}

public class TalkDataScript : MonoBehaviour
{
    [SerializeField]
    List<Scenario> scenarios = new List<Scenario>();

    // 今のシナリオを入れとく
    Scenario currentScenario;
    // シナリオ送信先
    textScript setText;

    int index = 0;
    int indexMax = 0;
    bool scenarioFinish = false;

    // チュートリアルを管理するデータ
    TutorialData data;

    // Start is called before the first frame update
    void Start()
    {
        setText = GameObject.Find("talk").GetComponent<textScript>();
        data = GameObject.Find("TutorialState").GetComponent<TutorialData>();

        var scenario01 = new Scenario()
        {
            ID = "scenario01",
            Texts = new List<string>()
            {
                "ある日あるところ…",
                "人里離れた森の奥にその見習い魔女は住んでいました。",
                "今日のご飯は何にしようか。クロちゃん？",
                "にゃ～",
                "今日はパンケーキがいいかなぁ",
                "にゃ！",
                "そうだ、クロちゃん！\n魔法で森の中に飛ばすから、食材を取ってきてくれない？",
                "にゃ！！",
                "せーの！！",
                "にゃーー！",
                "こうして、リリアとクロの食材集めが始まったのでした。"
            },

            Names = new List<string>()
            {
                "",
                "",
                "リリア",
                "クロ",
                "リリア",
                "クロ",
                "リリア",
                "クロ",
                "リリア",
                "クロ",
                "",
            }
        };

        // シナリオスタート
        SetScenario(scenario01);
        
        // プレイヤーを止める
    }

    // Update is called once per frame
    void Update()
    {
        if (scenarioFinish == true) return;

        if (setText.GetTextFinish() == true && Input.GetKeyDown(KeyCode.Return))
        {
            if (index < indexMax - 1)
            {
                index++;
                setText.SetText(currentScenario.Texts[index]);
            }
            //else if (index >= indexMax && scenarioFinish == true)
            //{
                
            //}
            else
            {
                scenarioFinish = true;
                data.TutorialNext();
            }
        }
    }

    public void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        index = 0;
        indexMax = currentScenario.Texts.Count;
        scenarioFinish = false;
        setText.SetTextFinish(false);
        setText.SetText(currentScenario.Texts[index]);
    }

    public string GetName()
    {
        return currentScenario.Names[index];
    }

    public string GetTexts()
    {
        return currentScenario.Texts[index];
    }
}

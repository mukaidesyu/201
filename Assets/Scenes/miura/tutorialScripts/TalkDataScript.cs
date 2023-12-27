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

    // ���̃V�i���I�����Ƃ�
    Scenario currentScenario;
    // �V�i���I���M��
    textScript setText;

    int index = 0;
    int indexMax = 0;
    bool scenarioFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        setText = GameObject.Find("talk").GetComponent<textScript>();

        var scenario01 = new Scenario()
        {
            ID = "scenario01",
            Texts = new List<string>()
            {
                "�ɂ�`",
                "�ǂ������́H",
                "�ɂ�`",
                "�����������́H",
                "�͂��A�˂�����"
            },

            Names = new List<string>()
            {
                "�N��",
                "�����A",
                "�N��",
                "�����A",
                "�����A"
            }
        };

        // �V�i���I�X�^�[�g
        SetScenario(scenario01);
        setText.SetText(currentScenario.Texts[index]);
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
            else
            {
                scenarioFinish = true;
            }
        }
    }

    public void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        index = 0;
        indexMax = currentScenario.Texts.Count;
        scenarioFinish = false;
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

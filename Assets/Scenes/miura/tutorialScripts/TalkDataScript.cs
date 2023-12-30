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

    // �`���[�g���A�����Ǘ�����f�[�^
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
                "���������Ƃ���c",
                "�l�����ꂽ�X�̉��ɂ��̌��K�������͏Z��ł��܂����B",
                "�����̂��т͉��ɂ��悤���B�N�������H",
                "�ɂ�`",
                "�����̓p���P�[�L���������Ȃ�",
                "�ɂ�I",
                "�������A�N�������I\n���@�ŐX�̒��ɔ�΂�����A�H�ނ�����Ă��Ă���Ȃ��H",
                "�ɂ�I�I",
                "���[�́I�I",
                "�ɂ�[�[�I",
                "�������āA�����A�ƃN���̐H�ޏW�߂��n�܂����̂ł����B"
            },

            Names = new List<string>()
            {
                "",
                "",
                "�����A",
                "�N��",
                "�����A",
                "�N��",
                "�����A",
                "�N��",
                "�����A",
                "�N��",
                "",
            }
        };

        // �V�i���I�X�^�[�g
        SetScenario(scenario01);
        
        // �v���C���[���~�߂�
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

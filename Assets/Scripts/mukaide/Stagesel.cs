using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class Stagesel : MonoBehaviour
{
    Button button;

    TextMeshProUGUI tmp;

    Image level;
    Image materials;
    public Sprite[] texture;

    [SerializeField] EventSystem eventsistem;

    GameObject focus;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("�A�T�Δ�").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();
        //�e�L�X�g�̕ύX
        tmp = GameObject.Find("stageno").GetComponent<TextMeshProUGUI>();

        level = GameObject.Find("Level1").GetComponent<Image>();
        materials = GameObject.Find("materialname").GetComponent<Image>();
        level.sprite = texture[0];

        audio = GetComponent<AudioSource>();

        focus = EventSystem.current.currentSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventsistem.currentSelectedGameObject.name != ("�^�C�g����"))
        {
            tmp.text = eventsistem.currentSelectedGameObject.name;
        }

        if (tmp.text == "�A�T�Δ�")
        {
            level.sprite = texture[0];
            materials.sprite = texture[3];
        }
        if (tmp.text == "�q�����X��")
        {
            level.sprite = texture[1];
            materials.sprite = texture[4];
        }
        if (tmp.text == "�o���R��")
        {
            level.sprite = texture[2];
            materials.sprite = texture[5];
        }
        if (focus != EventSystem.current.currentSelectedGameObject)
        {
            audio.PlayOneShot(audio.clip);
            focus = EventSystem.current.currentSelectedGameObject;
        }
    }
}

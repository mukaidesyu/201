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

   [SerializeField] EventSystem eventsistem;

    GameObject focus;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("�}�b�v�@�@�P").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();
        //�e�L�X�g�̕ύX
        tmp = GameObject.Find("stageno").GetComponent<TextMeshProUGUI>();

        audio = GetComponent<AudioSource>();

        focus = EventSystem.current.currentSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        tmp.text = eventsistem.currentSelectedGameObject.name;

        if (focus != EventSystem.current.currentSelectedGameObject)
        {
            audio.PlayOneShot(audio.clip);
            focus = EventSystem.current.currentSelectedGameObject;
        }
    }
}

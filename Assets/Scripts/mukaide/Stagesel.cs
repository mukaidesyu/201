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
        button = GameObject.Find("アサ湖畔").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
        //テキストの変更
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
        if (eventsistem.currentSelectedGameObject.name != ("タイトルへ"))
        {
            tmp.text = eventsistem.currentSelectedGameObject.name;
        }

        if (tmp.text == "アサ湖畔")
        {
            level.sprite = texture[0];
            materials.sprite = texture[3];
        }
        if (tmp.text == "ヒルメ森林")
        {
            level.sprite = texture[1];
            materials.sprite = texture[4];
        }
        if (tmp.text == "バン山脈")
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

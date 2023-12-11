using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeNikukyuu : MonoBehaviour
{
    bool finish = false;
    int ID;
    Image image;

    void Awake()
    {
        image = this.GetComponent<Image>();
        image.enabled = false;
    }
    void Start()
    {
        // ècâ°î‰ 1920x1080
        int x = Random.RandomRange(-86,86);
        x *= 10;
        int y = Random.RandomRange(-58, 58);
        y *= 10;
        GetComponent<RectTransform>().anchoredPosition = new Vector3(x,y,0);
        float angle = Random.RandomRange(-60, 60);
        GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,angle);
        float scale = Random.RandomRange(4.0f,10.0f);
        GetComponent<RectTransform>().localScale = new Vector3(scale, scale,0);
    }

    public void Appear()
    {
        image.enabled = true;
        finish = true;
    }

    public void Vanish()
    {
        image.enabled = false;
    }
    public bool GetFinish()
    {
        return finish;
    }

}

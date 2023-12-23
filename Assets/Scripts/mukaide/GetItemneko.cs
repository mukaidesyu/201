using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemneko : MonoBehaviour
{
    Image spriteRenderer;
    public Sprite[] sprite;
    Sprite now;
    Color color;

    public RectTransform itemtan;

    // Start is called before the first frame update
    void Start()
    {
        itemtan = GameObject.Find("Itemgetneko").gameObject.GetComponent<RectTransform>();
        spriteRenderer = GetComponent<Image>();
        now = sprite[0];
        color = gameObject.GetComponent<Image>().color;
        color.a = 0.0f;
        gameObject.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        //カットイン中にアイテムを出現させる
       if (itemtan.anchoredPosition.x >= 0)
       {
           color.a = 1.0f;
           gameObject.GetComponent<Image>().color = color;
       }
       else if (itemtan.anchoredPosition.x < 0)
       {
           color.a = 0.0f;
           gameObject.GetComponent<Image>().color = color;
       }
        spriteRenderer.sprite = now;
    }

    public void ItemSpriteChange(int no)
    {
        now = sprite[no];
    }
}

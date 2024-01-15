using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemgetUI : MonoBehaviour
{

    public bool isItemGet;
    [SerializeField]GameObject ItemGetPanel;
    GetItemneko get;
    RectTransform RectTransform_get;
    private float scale = 0;
    public Itemgetneko itemgetneko;

    // Start is called before the first frame update
    void Start()
    {
        isItemGet = false;
        ItemGetPanel = GameObject.Find("buck");
        itemgetneko = GameObject.Find("Itemgetneko").GetComponent<Itemgetneko>();
        RectTransform_get = ItemGetPanel.gameObject.GetComponent<RectTransform>();
        ItemGetPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ItemGetPanel.activeSelf == true &&itemgetneko.Nekofinish() == false)
        {
            scale += 0.1f;
            if(scale >= 1)
            {
                scale = 1.0f;
            }
            RectTransform_get.localScale = new Vector2(1.0f, scale);
        }

        if(itemgetneko.Nekofinish() == true)
        {
            Debug.Log("aaaaaaaaaa");
            scale -= 0.1f;
            if (scale <= 0)
            {
                scale = 0.0f;
            }
            RectTransform_get.localScale = new Vector2(1.0f, scale);
        }

    }

    public void SwitchItemGet()
    {
        Time.timeScale = 1;
        scale = 0;
        RectTransform_get.localScale = new Vector2(1.0f, scale);
        ItemGetPanel.SetActive(false);
    }

    public void SwitchItemGetStart(int no)
    {
        Time.timeScale = 0;
        ItemGetPanel.SetActive(true);
        get = GameObject.Find("Item").GetComponent<GetItemneko>();
        get.ItemSpriteChange(no);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemClear : MonoBehaviour
{
    // 各アイテムを
    [SerializeField]bool kinokoGet;
    [SerializeField] bool sakanaGet;
    [SerializeField] bool kari1Get;
    [SerializeField] bool kari2Get;
    [SerializeField] bool kari3Get;

    Image kinoko;
    Image sakana;
    Image kari1;
    Image kari2;
    Image kari3;

    // Start is called before the first frame update
    void Start()
    {
        kinoko = this.transform.GetChild(0).GetComponent<Image>();
        sakana = this.transform.GetChild(1).GetComponent<Image>();
        kari1 = this.transform.GetChild(2).GetComponent<Image>();
        kari2 = this.transform.GetChild(3).GetComponent<Image>();
        kari3 = this.transform.GetChild(4).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kinokoGet == true)// 変化処理
        {
            kinoko.color += new Color (0.1f, 0.1f, 0.1f, 0.1f);
            if (kinoko.color.a >= 1.0f)
            {
                kinoko.color = new Color(1, 1, 1, 1);
            }
        }

        if (sakanaGet == true)
        {
            sakana.color += new Color(0.01f, 0.01f, 0.01f, 0.01f);
            if (sakana.color.a >= 1.0f)
            {
                sakana.color = new Color(1, 1, 1, 1);
            }
        }

        if (kari1Get == true)
        {
            kari1.color += new Color(0.01f, 0.01f, 0.01f, 0.01f);
            if (kari1.color.a >= 1.0f)
            {
                kari1.color = new Color(1, 1, 1, 1);
            }
        }

        if (kari2Get == true)
        {
            kari2.color += new Color(0.01f, 0.01f, 0.01f, 0.01f);
            if (kari2.color.a >= 1.0f)
            {
                kari2.color = new Color(1, 1, 1, 1);
            }
        }

        if (kari3Get == true)
        {
            kari3.color += new Color(0.01f, 0.01f, 0.01f, 0.01f);
            if (kari3.color.a >= 1.0f)
            {
                kari3.color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void ClearStart()
    {
        GameObject getItems = GameObject.Find("GetItems");
        kinokoGet = getItems.transform.GetChild(0).GetComponent<Memo_UI>().GetIsGet();
        sakanaGet = getItems.transform.GetChild(1).GetComponent<Memo_UI>().GetIsGet();
        kari1Get = getItems.transform.GetChild(2).GetComponent<Memo_UI>().GetIsGet();
        kari2Get = getItems.transform.GetChild(3).GetComponent<Memo_UI>().GetIsGet();
        kari3Get = getItems.transform.GetChild(4).GetComponent<Memo_UI>().GetIsGet();
    }
}

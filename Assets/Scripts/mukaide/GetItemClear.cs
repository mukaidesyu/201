using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemClear : MonoBehaviour
{
    // 各アイテムを
    [SerializeField] bool kinokoGet;
    [SerializeField] bool sakanaGet;
    [SerializeField] bool kari1Get;
    [SerializeField] bool kari2Get;
    [SerializeField] bool kari3Get;

    Image kinoko;
    Image sakana;
    Image kari1;
    Image kari2;
    Image kari3;

    List<GameObject> getItems = new List<GameObject>();
    bool effectFinish;

    // Start is called before the first frame update
    void Start()
    {
        kinoko = this.transform.GetChild(0).GetComponent<Image>();
        sakana = this.transform.GetChild(1).GetComponent<Image>();
        kari1 = this.transform.GetChild(2).GetComponent<Image>();
        kari2 = this.transform.GetChild(3).GetComponent<Image>();
        kari3 = this.transform.GetChild(4).GetComponent<Image>();

        // 子オブジェクトを全部取ってくる
        for (int i = 0; i < this.transform.childCount; i++)
        {
            getItems.Add(transform.GetChild(i).gameObject);
        }

        effectFinish = false;
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

    private void FixedUpdate()
    {
        if (effectFinish == true) return;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            ItemBigToSmall script = getItems[i].GetComponent<ItemBigToSmall>();

            // ここむりやり
            switch (i)
            {
                case 0:
                    script.SetIsGet(kinokoGet);
                    break;
                case 1:
                    script.SetIsGet(sakanaGet);
                    break;
                case 2:
                    script.SetIsGet(kari1Get);
                    break;
                case 3:
                    script.SetIsGet(kari2Get);
                    break;
                case 4:
                    script.SetIsGet(kari3Get);
                    break;
            }

            ClearItemState state = script.GetState();

            if (state == ClearItemState.Finish && i != transform.childCount - 1)
            {
                getItems[i + 1].GetComponent<ItemBigToSmall>().StartEffect();
            }
            else if (state == ClearItemState.Finish && i >= transform.childCount - 1)
            {
                effectFinish = true;
            }
        }
    }

    public void ClearStart()
    {
        GameObject getItem = GameObject.Find("GetItems");
        kinokoGet = getItem.transform.GetChild(0).GetComponent<Memo_UI>().GetIsGet();
        sakanaGet = getItem.transform.GetChild(1).GetComponent<Memo_UI>().GetIsGet();
        kari1Get = getItem.transform.GetChild(2).GetComponent<Memo_UI>().GetIsGet();
        kari2Get = getItem.transform.GetChild(3).GetComponent<Memo_UI>().GetIsGet();
        kari3Get = getItem.transform.GetChild(4).GetComponent<Memo_UI>().GetIsGet();

        this.transform.GetChild(0).GetComponent<ItemBigToSmall>().StartEffect();
    }

}

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
                GameObject.Find("ClearTurnNumber").GetComponent<ClearTurnScript>().EffectStart();
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

    public bool EfFinish()
    {
        return effectFinish;
    }
}

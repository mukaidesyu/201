using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetItemClear : MonoBehaviour
{
    // 各アイテムを
    [SerializeField] bool item0Get;
    [SerializeField] bool item1Get;
    [SerializeField] bool item2Get;
    [SerializeField] bool item3Get;
    [SerializeField] bool item4Get;

    Image item0;
    Image item1;
    Image item2;
    Image item3;
    Image item4;

    List<GameObject> getItems = new List<GameObject>();
    bool effectFinish;
    int ChildConut;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        ChildConut = 0;
        // 子オブジェクトを全部取ってくる
        for (int i = 0; i < this.transform.childCount; i++)
        {
            getItems.Add(transform.GetChild(i).gameObject);
            ChildConut++;
        }

        item0 = this.transform.GetChild(0).GetComponent<Image>();
        item1 = this.transform.GetChild(1).GetComponent<Image>();
        if (ChildConut > 2) item2 = this.transform.GetChild(2).GetComponent<Image>();
        if (ChildConut > 3) item3 = this.transform.GetChild(3).GetComponent<Image>();
        if (ChildConut > 4) item4 = this.transform.GetChild(4).GetComponent<Image>();



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
                    script.SetIsGet(item0Get);
                    break;
                case 1:
                    script.SetIsGet(item1Get);
                    break;
                case 2:
                    script.SetIsGet(item2Get);
                    break;
                case 3:
                    script.SetIsGet(item3Get);
                    break;
                case 4:
                    script.SetIsGet(item4Get);
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
        item0Get = getItem.transform.GetChild(0).GetComponent<Memo_UI>().GetIsGet();
        item1Get = getItem.transform.GetChild(1).GetComponent<Memo_UI>().GetIsGet();
        if(ChildConut > 2) item2Get = getItem.transform.GetChild(2).GetComponent<Memo_UI>().GetIsGet();
        if(ChildConut > 3) item3Get = getItem.transform.GetChild(3).GetComponent<Memo_UI>().GetIsGet();
        if(ChildConut > 4) item4Get = getItem.transform.GetChild(4).GetComponent<Memo_UI>().GetIsGet();

        this.transform.GetChild(0).GetComponent<ItemBigToSmall>().StartEffect();
    }

    public bool EfFinish()
    {
        return effectFinish;
    }
}

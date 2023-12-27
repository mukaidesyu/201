using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemgetUI : MonoBehaviour
{

    public bool isItemGet;
    GameObject ItemGetPanel;
    GetItemneko get;

    // Start is called before the first frame update
    void Start()
    {
        isItemGet = false;
        ItemGetPanel = GameObject.Find("buck");
        ItemGetPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SwitchItemGet()
    {

        Time.timeScale = 1;
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

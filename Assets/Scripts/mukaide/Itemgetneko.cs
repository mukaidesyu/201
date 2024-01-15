using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemgetneko : MonoBehaviour
{
    public RectTransform Nekotan;

    public float move = 5;

    ItemgetUI ui;
    public bool nekogetfinish = false;
 
    public float cnt = 60;
     
    // Start is called before the first frame update
    void Start()
    {
        Nekotan = this.gameObject.GetComponent<RectTransform>();
        ui = GameObject.Find("ItemGet").GetComponent<ItemgetUI>();
        Nekotan.anchoredPosition = new Vector3(-500, -120, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Nekotan.position += new Vector3(move, 0, 0);

        if(Nekotan.anchoredPosition.x >= 400)
        {
            cnt -= 1.0f;
            Nekotan.anchoredPosition = new Vector3(400, -120, 0);
        }
        if(cnt <= 10)
        {
            nekogetfinish = true;
        }
        if(cnt <= 0)
        {
            ui.SwitchItemGet();
            Nekotan.anchoredPosition = new Vector3(-500, -120, 0);
            nekogetfinish = false;
            cnt = 40;
        }
    }

    public bool Nekofinish()
    {
        return nekogetfinish;
    }

}

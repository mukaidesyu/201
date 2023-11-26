using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memo_UI : MonoBehaviour
{
    bool isGet;
    GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        isGet = false;
        child = this.transform.GetChild(0).gameObject;
        child.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGet)
        {
            child.GetComponent<Image>().enabled = true;
        }
    }

    public void SetIsGet(bool set)
    {
        isGet = set;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CharaChange : MonoBehaviour
{

    public Image image;
    public Sprite[] sprite;
    //int index;

    // Use this for initialization
    void Start()
    {
        //index = 0;

        image = this.GetComponent<Image>();
        //image.sprite = sprite[index];
        image.sprite = sprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        // J キーが押された時
        if (Input.GetKeyDown(KeyCode.J))
        {
            //index++;
            //image.sprite = sprite[1];
            CharaChange1();//1の表情を出す
        }
        // K キーが押された時
        if (Input.GetKeyDown(KeyCode.K))
        {
            CharaChange2();//2の表情を出す
        }
        // L キーが押された時
        if (Input.GetKeyDown(KeyCode.L))
        {
            CharaChange3();//3の表情を出す
        }
        // M キーが押された時
        if (Input.GetKeyDown(KeyCode.M))
        {
            CharaReturn();//0の表情を出す
        }
    }

    void CharaChange1()//1の表情を出す関数
    {
        image.sprite = sprite[1];
    }
    void CharaChange2()//2の表情を出す関数
    {
        image.sprite = sprite[2];
    }
    void CharaChange3()//3の表情を出す関数
    {
        image.sprite = sprite[3];
    }
    void CharaReturn()//0の表情を出す関数
    {
        image.sprite = sprite[0];
    }

}


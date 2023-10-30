
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
        // J �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.J))
        {
            //index++;
            //image.sprite = sprite[1];
            CharaChange1();//1�̕\����o��
        }
        // K �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.K))
        {
            CharaChange2();//2�̕\����o��
        }
        // L �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.L))
        {
            CharaChange3();//3�̕\����o��
        }
        // M �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.M))
        {
            CharaReturn();//0�̕\����o��
        }
    }

    void CharaChange1()//1�̕\����o���֐�
    {
        image.sprite = sprite[1];
    }
    void CharaChange2()//2�̕\����o���֐�
    {
        image.sprite = sprite[2];
    }
    void CharaChange3()//3�̕\����o���֐�
    {
        image.sprite = sprite[3];
    }
    void CharaReturn()//0�̕\����o���֐�
    {
        image.sprite = sprite[0];
    }

}


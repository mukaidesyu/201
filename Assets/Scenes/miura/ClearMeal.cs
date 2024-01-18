using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearMeal : MonoBehaviour
{
    bool appear = false;
    string sceneName;
    int rank; // 1��A,2��B,3��C
    TextMeshProUGUI tmPro;
    string text;

    // Start is called before the first frame update
    void Start()
    {
        tmPro = this.GetComponent<TextMeshProUGUI>();
        appear = false;
        sceneName = SceneManager.GetActiveScene().name;
        rank = 3;
        text = ("�u?????????�v").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (appear == true)
        {
            if (sceneName == "tutorial")
            {
                text = ("�u�`���[�g���A���V�`���[�v").ToString();
            }
            else if (sceneName == "Game1")
            {
                switch (rank) 
                {
                    case 1:
                        text = ("�u�p���P�[�L�X�y�V�����v").ToString();
                        break;
                    case 2:
                        text = ("�u�ق��ق��p���P�[�L�v").ToString();
                        break;
                    case 3:
                        text = ("�u�p���P�[�L...�H�H�v").ToString();
                        break;
                }
            }
            else if (sceneName == "Game2")
            {
                switch (rank)
                {
                    case 1:
                        text = ("�u�Ƃ�Ƃ�J���{�i�[���v").ToString();
                        break;
                    case 2:
                        text = ("�u�ł����ăJ���{�i�[���v").ToString();
                        break;
                    case 3:
                        text = ("�u�����ς��J���{�i�[���v").ToString();
                        break;
                }
            }
            else if (sceneName == "Game3")
            {
                switch (rank)
                {
                    case 1:
                        text = ("�u�������ȃV�`���[�v").ToString();
                        break;
                    case 2:
                        text = ("�u���������V�`���[�v").ToString();
                        break;
                    case 3:
                        text = ("�u�ނ炳���V�`���[�v").ToString();
                        break;
                }
            }
        }

        tmPro.text = text;
    }

    public void GoAppear() 
    {
        appear = true;
    }

    public void SetRank(int set) 
    {
        rank = set;
    }
}

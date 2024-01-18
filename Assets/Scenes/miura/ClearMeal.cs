using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearMeal : MonoBehaviour
{
    bool appear = false;
    string sceneName;
    int rank; // 1がA,2がB,3がC
    TextMeshProUGUI tmPro;
    string text;

    // Start is called before the first frame update
    void Start()
    {
        tmPro = this.GetComponent<TextMeshProUGUI>();
        appear = false;
        sceneName = SceneManager.GetActiveScene().name;
        rank = 3;
        text = ("「?????????」").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (appear == true)
        {
            if (sceneName == "tutorial")
            {
                text = ("「チュートリアルシチュー」").ToString();
            }
            else if (sceneName == "Game1")
            {
                switch (rank) 
                {
                    case 1:
                        text = ("「パンケーキスペシャル」").ToString();
                        break;
                    case 2:
                        text = ("「ほかほかパンケーキ」").ToString();
                        break;
                    case 3:
                        text = ("「パンケーキ...？？」").ToString();
                        break;
                }
            }
            else if (sceneName == "Game2")
            {
                switch (rank)
                {
                    case 1:
                        text = ("「とろとろカルボナーラ」").ToString();
                        break;
                    case 2:
                        text = ("「できたてカルボナーラ」").ToString();
                        break;
                    case 3:
                        text = ("「しっぱいカルボナーラ」").ToString();
                        break;
                }
            }
            else if (sceneName == "Game3")
            {
                switch (rank)
                {
                    case 1:
                        text = ("「おさかなシチュー」").ToString();
                        break;
                    case 2:
                        text = ("「あったかシチュー」").ToString();
                        break;
                    case 3:
                        text = ("「むらさきシチュー」").ToString();
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

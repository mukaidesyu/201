using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool isPauce;
    GameObject pausePanel;

    [SerializeField] Button button;

    // Start is called before the first frame update
    void Start()
    {
        isPauce = false;
        pausePanel = GameObject.Find("PauseCanvas");
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
            button = GameObject.Find("ToSelect").GetComponent<Button>();
            //ボタンが選択された状態になる
            button.Select();
        }

        // このへんに記述すれば多分動く
    }

    public bool GetPause()
    {
        return isPauce;
    } 

    public void SwitchPause()
    {
        if (isPauce) // ポーズ中
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else // ポーズして無い時
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        isPauce = !isPauce;
    }
}

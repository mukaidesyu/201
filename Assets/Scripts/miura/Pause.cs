using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPauce;
    GameObject pausePanel;

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopPause();
        }

        // このへんに記述すれば多分動く
    }

    public bool GetPause()
    {
        return isPauce;
    } 

    public void StopPause()
    {
        if (isPauce) // ポーズ中
        {
            Debug.Log("ポーズ解除します！");
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else // ポーズして無い時
        {
            Debug.Log("ポーズします！");
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        isPauce = !isPauce;
    }
}

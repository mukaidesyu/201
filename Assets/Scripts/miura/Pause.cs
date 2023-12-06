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

        // ���̂ւ�ɋL�q����Α�������
    }

    public bool GetPause()
    {
        return isPauce;
    } 

    public void StopPause()
    {
        if (isPauce) // �|�[�Y��
        {
            Debug.Log("�|�[�Y�������܂��I");
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else // �|�[�Y���Ė�����
        {
            Debug.Log("�|�[�Y���܂��I");
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        isPauce = !isPauce;
    }
}

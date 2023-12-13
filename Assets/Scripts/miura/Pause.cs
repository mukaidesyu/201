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
            //�{�^�����I�����ꂽ��ԂɂȂ�
            button.Select();
        }

        // ���̂ւ�ɋL�q����Α�������
    }

    public bool GetPause()
    {
        return isPauce;
    } 

    public void SwitchPause()
    {
        if (isPauce) // �|�[�Y��
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else // �|�[�Y���Ė�����
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        isPauce = !isPauce;
    }
}

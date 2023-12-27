using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    bool downFlag = false;
    float DownTime = 10;
    float UpTime = 10;
    float TargetPosY = -300;
    RectTransform rectTransform;
    Vector3 startPos;
    float startMove;
    Vector3 targetPos;
    float targetMove;
    bool isStop;
    string[] controllerNames;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
        startMove = (targetPos.y - startPos.y) / DownTime;
        targetPos = new Vector3(startPos.x, TargetPosY ,0);
        targetMove = (startPos.y - targetPos.y) / UpTime;
        downFlag = false;
        isStop = false;
        controllerNames = Input.GetJoystickNames();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop == true) return;

        // キーの判定
        if ((Input.GetKeyDown(KeyCode.Space) && (controllerNames[0] == ""))|| (Input.GetAxis("TriggerLR") < 0)) //|| (Input.GetKeyDown("joystick button 6") && Input.GetKeyDown("joystick button 7"))) // いじる前
        {
            downFlag = true;
        }
        if ((Input.GetKeyUp(KeyCode.Space) && (controllerNames[0] == "")) || (Input.GetAxis("TriggerLR") >= 0))
        {
            downFlag = false;
        }

        // ボタンを押し続けている間の処理
        if (downFlag)
        {
            rectTransform.position -= new Vector3(0,targetMove,0);

            if (rectTransform.position.y <= targetPos.y)
            {
                rectTransform.position = targetPos;
            }
        }
        else // ボタンを押してないときの処理
        {
            rectTransform.position -= new Vector3(0, startMove, 0);

            if (rectTransform.position.y >= startPos.y)
            {
                rectTransform.position = startPos;
            }
        }
    }


    // 上げ下げする関数
    public void StopMapDown()
    {
        isStop = true;
    }

    public void StartMapDown()
    {
        isStop = false;
    }
}

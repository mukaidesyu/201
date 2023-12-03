using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    bool downFlag = false;
    public float DownTime;
    public float UpTime;
    public float TargetPosY;
    RectTransform rectTransform;
    Vector3 startPos;
    float startMove;
    Vector3 targetPos;
    float targetMove;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
        startMove = (targetPos.y - startPos.y) / DownTime;
        targetPos = new Vector3(startPos.x, TargetPosY ,0);
        targetMove = (startPos.y - targetPos.y) / UpTime;
        downFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // キーの判定
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown("joystick button 6") && Input.GetKeyDown("joystick button 7")))
        {
            downFlag = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || (Input.GetKeyDown("joystick button 6") && Input.GetKeyDown("joystick button 7")))
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
}

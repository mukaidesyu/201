using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    bool downFlag = false;
    public float DownTime;
    public float UpTime;
    RectTransform rectTransform;
    Vector3 startPos;
    float startMove;
    public Vector3 targetPos;
    float targetMove;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
        startMove = (targetPos.y - startPos.y) / DownTime;
        targetMove = (startPos.y - targetPos.y) / UpTime;
        downFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // キーの判定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            downFlag = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            downFlag = false;
        }

        // ボタンを押し続けている間の処理
        if (downFlag)
        {
            rectTransform.position -= new Vector3(0,targetMove,0);

            Debug.Log(rectTransform.position);
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

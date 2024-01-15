using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko_Camera : MonoBehaviour
{
    //回転させるスピード
    public float rotateSpeed = 3.0f;
    Vector3 playerPos;
    bool startAngle = false;

    // Use this for initialization
    void Start()
    {
        startAngle = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー位置情報
        playerPos = this.transform.position;

        if (Input.GetKey(KeyCode.O) || Input.GetAxis("Horizontal2") > 0.5f)
        {
            startAngle = false;
            //カメラを回転させる
            transform.RotateAround(playerPos, Vector3.up, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.U) || Input.GetAxis("Horizontal2") < -0.5f)
        {
            startAngle = false;
            //カメラを回転させる
            transform.RotateAround(playerPos, Vector3.up, -rotateSpeed);
        }


        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown("joystick button 9"))
        {
            startAngle = true;
        }

        if (startAngle)
        {
            CameraFoward();
        }
    }

    void CameraFoward()
    {
        float angle = Mathf.LerpAngle(transform.eulerAngles.y, Vector3.forward.y, 0.3f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
    }
}
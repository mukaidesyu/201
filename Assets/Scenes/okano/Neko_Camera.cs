using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko_Camera : MonoBehaviour
{
    //回転させるスピード
    public float rotateSpeed = 3.0f;
    Vector3 playerPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー位置情報
        playerPos = this.transform.position;

        if (Input.GetKey(KeyCode.O) || Input.GetAxis("Horizontal2") > 0.5f)
        {           
            //カメラを回転させる
            transform.RotateAround(playerPos, Vector3.up, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.U) || Input.GetAxis("Horizontal2") < -0.5f)
        {
            //カメラを回転させる
            transform.RotateAround(playerPos, Vector3.up, -rotateSpeed);
        }
    }
}
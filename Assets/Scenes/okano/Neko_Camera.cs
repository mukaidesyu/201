using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko_Camera : MonoBehaviour
{
    //プレイヤーを変数に格納
    public GameObject Player;

    //回転させるスピード
    public float rotateSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー位置情報
        Vector3 playerPos = Player.transform.position;

        if (Input.GetKey(KeyCode.O))
        {           
            //カメラを回転させる
            transform.RotateAround(playerPos, Vector3.up, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            //カメラを回転させる
            transform.RotateAround(playerPos, Vector3.up, -rotateSpeed);
        }
    }
}
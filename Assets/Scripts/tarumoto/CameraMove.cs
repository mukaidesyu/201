using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの情報を取得
        GameObject player = GameObject.Find("Neko");
        
        if (player != null)// プレイヤーがいるか確認
        {
            // プレイヤーのいる位置にカメラを横移動させる
            Vector3 pos = player.transform.position; // GetComponentであるかないか確認しなくてよい
            Vector3 camPos = gameObject.transform.position;
            camPos.x = pos.x;

            // パラメータ更新後データを上書きする
            gameObject.transform.position = camPos;
        }

        
    }
}

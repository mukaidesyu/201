using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoMove : MonoBehaviour
{
    enum NekoState
    {
        Stop = 0,
        Think,
        Move
    }


    [SerializeField] private float _speed = 5.0f;
    private float distance = 1.0f;
    private Vector2 move;
    private Vector3 targetPos;
    

    [SerializeField] bool IsMove; // 動いていいタイミングかどうか
    bool frontMove; // 前のパネルに動けるかどうか
    [SerializeField] NekoFront nekoFrontScript;
    [SerializeField] int stopCount; // 歩けないと判断する回数 
    [SerializeField] NekoState state; // 歩けないと判断する回数 
    

    private void Start()
    {
        targetPos = transform.position;

        IsMove = false;
        stopCount = 3; // 前、右、左の3つで判断
        nekoFrontScript = GameObject.Find("NekoFront").GetComponent<NekoFront>();
        state = NekoState.Think;
    }
    void Update()
    {
        if (IsMove) // 猫の動き
        {
            switch (state)
            {
                case NekoState.Think:

                    // 前のパネルに動けるかどうか
                    frontMove = nekoFrontScript.GetWalkFront();
                    // 動ける時
                    if (frontMove)
                    {
                        // 次のパネルに移動
                        var target = nekoFrontScript.GetFrontPanel();
                        targetPos = target.transform.position;

                        // 暫定的にワープ
                        this.transform.position = targetPos;

                        stopCount = 3;
                    }
                    else
                    {
                        stopCount--;

                        // 左右に向く
                        // とりあえず右から
                        if (stopCount == 2)
                        {
                            Debug.Log("右向くにゃ！");
                            transform.localEulerAngles += new Vector3(90, 0, 0);
                            IsMove = false;

                        }
                        else if (stopCount == 1) // 反対方向
                        {
                            Debug.Log("左向くにゃ！");
                            transform.localEulerAngles += new Vector3(-180, 0, 0);
                        }


                        if (stopCount <= 0)
                        {
                            Debug.Log("止まるにゃ！");
                            IsMove = false;// とりあえず止まる
                            state = NekoState.Stop;
                        }
                    }


                    break;


            }




        }
    }

}


//猫が歩くまで
//1. 目の前のパネル歩ける歩けないか判断する

//歩けない時
//歩けないカウント+1
//2.右か左かに向いて判定
//後ろは絶対向かない

//歩ける時
//2.１マス前に歩く
//歩けないカウントを0にする

// 猫のあるきかた
//重なったピースを１マス踏む
//そのあと置いたピースの
//一番遠いマスを踏む
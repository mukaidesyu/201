using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoMove : MonoBehaviour
{
    enum NekoState
    {
        Stop = 0,
        Think,
        Move,
        Rotate
    }

// 猫の移動関係
    // 移動時間
    private Vector3 targetPos;
    [SerializeField] private float _speed = 3.0f;


    [SerializeField] bool IsMove; // 動いていいタイミングかどうか
    bool frontMove; // 前のパネルに動けるかどうか
    [SerializeField] NekoFront nekoFrontScript;
    [SerializeField] int stopCount; // 歩けないと判断する回数 
    [SerializeField] NekoState state; // 歩けないと判断する回数 
    

    private void Start()
    {
        targetPos = transform.position;

        IsMove = false;
        stopCount = 2; // 前、右、左の3つで判断
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
                    Debug.Log(frontMove);

                    // 動ける時
                    if (frontMove)
                    {
                        // 目的地を前のパネルに設定
                        var target = nekoFrontScript.GetFrontPanel(); // ここ怪しそう
                        targetPos = target.transform.position;

 
                        // 猫の前をfalseに戻す 
                        nekoFrontScript.SetWalkFront(false);

                        stopCount = 2;

                        // 歩きモードへ
                        state = NekoState.Move;
                    }
                    else
                    {
                        state = NekoState.Rotate;
                    }


                    break;


                case NekoState.Move:
                    transform.position = Vector3.MoveTowards(transform.position, targetPos,_speed * Time.deltaTime);

                    float distance = Vector3.Distance(this.transform.position, targetPos);
                    // 着いたら止まる
                    if (distance <= 0.05)
                    {
                        state = NekoState.Think;
                    }

                    break;

                case NekoState.Rotate:
                  

                    // 左右に向く
                    // とりあえず右から
                    if (stopCount == 2)
                    {
                        stopCount--;
                        Debug.Log("右向くにゃ！");
                        transform.Rotate(new Vector3(0, 90, 0));
                        state = NekoState.Think;
                    }
                    else if (stopCount == 1)
                    {
                        stopCount--;
                        Debug.Log("左向くにゃ！");
                        transform.Rotate(new Vector3(0, 180, 0));
                        state = NekoState.Think;
                    }
                    else if (stopCount <= 0)
                    {
                        Debug.Log("止まるにゃ！");
                        transform.Rotate(new Vector3(0, 90, 0));
                        IsMove = false;
                        state = NekoState.Stop;
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
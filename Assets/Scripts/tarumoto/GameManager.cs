using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Spawner spawner;    // スポナー
    Piece activePiece;  // 生成されたピース 

    private void Start()
    {
        // スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();

        // スポナークラスからピース生成関数を呼んで変数に格納する
        if (!activePiece)
        {
            //activePiece = spawner.SpawnPiece();
        }
    }  
}

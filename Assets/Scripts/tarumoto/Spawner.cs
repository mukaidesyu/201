using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 配列の作成（ピースをすべて格納）
    [SerializeField]
    Piece[] pieces;

    // ランダムにピースを一つ選ぶ関数
    Piece GetRandomPiece()
    {
        int i = Random.Range(0, pieces.Length);

        if (pieces[i])
        {
            return pieces[i];
        }
        else
        {
            return null;
        }
    }

    // 選ばれたピースを生成する関数
    public Piece SpawnPiece()
    {
        Piece piece = Instantiate(GetRandomPiece(), transform.position, Quaternion.identity);

        if (piece)
        {
            return piece;
        }
        else
        {
            return null;
        }
    }
}
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
        int i = Random.Range(0,pieces.Length);

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
    public Piece SpawnPiece(GameObject player)
    {
        var playerpos = player.transform;

        Piece piece = Instantiate(GetRandomPiece(), transform.position, Quaternion.identity, playerpos);

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
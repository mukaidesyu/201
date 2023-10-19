using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // �z��̍쐬�i�s�[�X�����ׂĊi�[�j
    [SerializeField]
    Piece[] pieces;

    // �����_���Ƀs�[�X����I�Ԋ֐�
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

    // �I�΂ꂽ�s�[�X�𐶐�����֐�
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
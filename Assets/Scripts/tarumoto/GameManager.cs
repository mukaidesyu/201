using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Spawner spawner;    // �X�|�i�[
    Piece activePiece;  // �������ꂽ�s�[�X 

    private void Start()
    {
        // �X�|�i�[�I�u�W�F�N�g���X�|�i�[�ϐ��Ɋi�[����
        spawner = GameObject.FindObjectOfType<Spawner>();

        // �X�|�i�[�N���X����s�[�X�����֐����Ă�ŕϐ��Ɋi�[����
        if (!activePiece)
        {
            //activePiece = spawner.SpawnPiece();
        }
    }  
}

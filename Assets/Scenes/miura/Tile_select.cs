using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_select : MonoBehaviour
{
    // ������p�l�����ǂ���
    public bool IsWalk;

    // Start is called before the first frame update
    void Start()
    {
        //�@�p�l�����o�鎞�ɂƂ肠�����������A�K�v���H
        IsWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �p�l���̏�Ԃɂ���ĐF���ς��
        // �^�C���̃^�O���ς��
        switch (IsWalk)
        {
            case true:
                this.gameObject.layer = 6;
                break;
            case false:
                this.gameObject.layer = 7;
                break;
        }
    }
}

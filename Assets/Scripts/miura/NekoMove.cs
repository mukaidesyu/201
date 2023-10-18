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
    

    [SerializeField] bool IsMove; // �����Ă����^�C�~���O���ǂ���
    bool frontMove; // �O�̃p�l���ɓ����邩�ǂ���
    [SerializeField] NekoFront nekoFrontScript;
    [SerializeField] int stopCount; // �����Ȃ��Ɣ��f����� 
    [SerializeField] NekoState state; // �����Ȃ��Ɣ��f����� 
    

    private void Start()
    {
        targetPos = transform.position;

        IsMove = false;
        stopCount = 3; // �O�A�E�A����3�Ŕ��f
        nekoFrontScript = GameObject.Find("NekoFront").GetComponent<NekoFront>();
        state = NekoState.Think;
    }
    void Update()
    {
        if (IsMove) // �L�̓���
        {
            switch (state)
            {
                case NekoState.Think:

                    // �O�̃p�l���ɓ����邩�ǂ���
                    frontMove = nekoFrontScript.GetWalkFront();
                    // �����鎞
                    if (frontMove)
                    {
                        // ���̃p�l���Ɉړ�
                        var target = nekoFrontScript.GetFrontPanel();
                        targetPos = target.transform.position;

                        // �b��I�Ƀ��[�v
                        this.transform.position = targetPos;

                        stopCount = 3;
                    }
                    else
                    {
                        stopCount--;

                        // ���E�Ɍ���
                        // �Ƃ肠�����E����
                        if (stopCount == 2)
                        {
                            Debug.Log("�E�����ɂ�I");
                            transform.localEulerAngles += new Vector3(90, 0, 0);
                            IsMove = false;

                        }
                        else if (stopCount == 1) // ���Ε���
                        {
                            Debug.Log("�������ɂ�I");
                            transform.localEulerAngles += new Vector3(-180, 0, 0);
                        }


                        if (stopCount <= 0)
                        {
                            Debug.Log("�~�܂�ɂ�I");
                            IsMove = false;// �Ƃ肠�����~�܂�
                            state = NekoState.Stop;
                        }
                    }


                    break;


            }




        }
    }

}


//�L�������܂�
//1. �ڂ̑O�̃p�l������������Ȃ������f����

//�����Ȃ���
//�����Ȃ��J�E���g+1
//2.�E�������Ɍ����Ĕ���
//���͐�Ό����Ȃ�

//�����鎞
//2.�P�}�X�O�ɕ���
//�����Ȃ��J�E���g��0�ɂ���

// �L�̂��邫����
//�d�Ȃ����s�[�X���P�}�X����
//���̂��ƒu�����s�[�X��
//��ԉ����}�X�𓥂�
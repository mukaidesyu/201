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

// �L�̈ړ��֌W
    // �ړ�����
    private Vector3 targetPos;
    [SerializeField] private float _speed = 3.0f;


    [SerializeField] bool IsMove; // �����Ă����^�C�~���O���ǂ���
    bool frontMove; // �O�̃p�l���ɓ����邩�ǂ���
    [SerializeField] NekoFront nekoFrontScript;
    [SerializeField] int stopCount; // �����Ȃ��Ɣ��f����� 
    [SerializeField] NekoState state; // �����Ȃ��Ɣ��f����� 
    

    private void Start()
    {
        targetPos = transform.position;

        IsMove = false;
        stopCount = 2; // �O�A�E�A����3�Ŕ��f
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
                    Debug.Log(frontMove);

                    // �����鎞
                    if (frontMove)
                    {
                        // �ړI�n��O�̃p�l���ɐݒ�
                        var target = nekoFrontScript.GetFrontPanel(); // ������������
                        targetPos = target.transform.position;

 
                        // �L�̑O��false�ɖ߂� 
                        nekoFrontScript.SetWalkFront(false);

                        stopCount = 2;

                        // �������[�h��
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
                    // ��������~�܂�
                    if (distance <= 0.05)
                    {
                        state = NekoState.Think;
                    }

                    break;

                case NekoState.Rotate:
                  

                    // ���E�Ɍ���
                    // �Ƃ肠�����E����
                    if (stopCount == 2)
                    {
                        stopCount--;
                        Debug.Log("�E�����ɂ�I");
                        transform.Rotate(new Vector3(0, 90, 0));
                        state = NekoState.Think;
                    }
                    else if (stopCount == 1)
                    {
                        stopCount--;
                        Debug.Log("�������ɂ�I");
                        transform.Rotate(new Vector3(0, 180, 0));
                        state = NekoState.Think;
                    }
                    else if (stopCount <= 0)
                    {
                        Debug.Log("�~�܂�ɂ�I");
                        transform.Rotate(new Vector3(0, 90, 0));
                        IsMove = false;
                        state = NekoState.Stop;
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
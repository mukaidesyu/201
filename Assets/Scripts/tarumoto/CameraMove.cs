using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̏����擾
        GameObject player = GameObject.Find("Neko");
        
        if (player != null)// �v���C���[�����邩�m�F
        {
            // �v���C���[�̂���ʒu�ɃJ���������ړ�������
            Vector3 pos = player.transform.position; // GetComponent�ł��邩�Ȃ����m�F���Ȃ��Ă悢
            Vector3 camPos = gameObject.transform.position;
            camPos.x = pos.x;

            // �p�����[�^�X�V��f�[�^���㏑������
            gameObject.transform.position = camPos;
        }

        
    }
}

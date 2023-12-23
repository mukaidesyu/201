using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko_Camera : MonoBehaviour
{
    //�v���C���[��ϐ��Ɋi�[
    public GameObject Player;

    //��]������X�s�[�h
    public float rotateSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�ʒu���
        Vector3 playerPos = Player.transform.position;

        if (Input.GetKey(KeyCode.O))
        {           
            //�J��������]������
            transform.RotateAround(playerPos, Vector3.up, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            //�J��������]������
            transform.RotateAround(playerPos, Vector3.up, -rotateSpeed);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracataut : MonoBehaviour
{
    //�v���C���[��ϐ��Ɋi�[
    public GameObject Player;

    //��]������X�s�[�h
    public float rotateSpeed = 100.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //��]������p�x
        float angle = -1 * rotateSpeed * Time.deltaTime;

        //�v���C���[�ʒu���
        Vector3 playerPos = Player.transform.position;

        //�J��������]������
        transform.RotateAround(playerPos, Vector3.up, angle);
    }
}

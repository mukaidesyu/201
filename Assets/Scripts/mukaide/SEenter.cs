using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEenter : MonoBehaviour
{
    //�Đ��ӏ�
    public AudioSource Audio;

    //���ʉ�
    public AudioClip enter;//�s�[�X�u�������̉�

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //�s�[�X�u�������̉�
    public void EnterSE()
    {
        Audio.PlayOneShot(enter);
    }
}

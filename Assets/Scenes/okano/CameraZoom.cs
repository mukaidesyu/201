using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    Transform tf; //Main Camera��Transform
    Camera cam; //Main Camera��Camera
    public float scroll = 1.0f;

    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main Camera��Transform���擾����B
        cam = this.gameObject.GetComponent<Camera>(); //Main Camera��Camera���擾����B
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.H)) //I�L�[��������Ă����
        {
            cam.fieldOfView = cam.fieldOfView - scroll; //�Y�[���C���B
        }
        else if (Input.GetKey(KeyCode.J)) //O�L�[��������Ă����
        {
            cam.fieldOfView = cam.fieldOfView + scroll; //�Y�[���A�E�g�B
        }
        cam.fieldOfView = Mathf.Clamp(value: cam.fieldOfView, min: -10.0f, max: 40.0f);
    }
}
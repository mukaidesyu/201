using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera
    public float scroll = 1.0f;

    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.H)) //Iキーが押されていれば
        {
            cam.fieldOfView = cam.fieldOfView - scroll; //ズームイン。
        }
        else if (Input.GetKey(KeyCode.J)) //Oキーが押されていれば
        {
            cam.fieldOfView = cam.fieldOfView + scroll; //ズームアウト。
        }
        cam.fieldOfView = Mathf.Clamp(value: cam.fieldOfView, min: -10.0f, max: 40.0f);
    }
}
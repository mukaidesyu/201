using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearbutton : MonoBehaviour
{
   [SerializeField] Button button;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("����������");
        button = GameObject.Find("nextbutton").GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventmanager : MonoBehaviour
{
    TreasureCount treasure;

    //�L�����ɌĂ�łق����֐�(�^�C���̃C�x���g�t���O�������Ă��̂��Ƃ�����)
    //�����炢���ȓ����ǉ����Ă�������҂��ĂĂق����Ƃ肠�����ō����
    public void Event()
    {
        treasure.TreasurePlus();
    }

    // Start is called before the first frame update
    void Start()
    {
        treasure = GameObject.Find("UI_TreasureCount").GetComponent<TreasureCount>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("�����Z�I");
            Event();
        }
    }

}

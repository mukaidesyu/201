using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventmanager : MonoBehaviour
{
    public GameObject[] MemoUI;
    TreasureCount treasure;

    //�L�����ɌĂ�łق����֐�(�^�C���̃C�x���g�t���O�������Ă��̂��Ƃ�����)
    //�����炢���ȓ����ǉ����Ă�������҂��ĂĂق����Ƃ肠�����ō����
    public void Event(GameObject eventTile) // �����C�x���g�̎��
    {
        Tilemanager script = eventTile.GetComponent<Tilemanager>();
        switch (script.GetEvent())// �C�x���g���e���X�C�b�`������
        {
            case EventStatus.Kinoko:
                // �����ɉ��o�I�ȏ���

                // �擾��ԂɕύX
                MemoUI[0].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kinoko_Got);
                break;

            case EventStatus.Sakana:
                // �����ɉ��o�I�ȏ���


                MemoUI[1].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Sakana_Got);
                break;
            case EventStatus.Kari1:
                treasure.TreasurePlus();
                // �����ɉ��o�I�ȏ���

                MemoUI[2].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari1_Got);
                break;

            case EventStatus.Kari2:
                // �����ɉ��o�I�ȏ���

                MemoUI[3].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari2_Got);
                break;
            case EventStatus.Kari3:
                // �����ɉ��o�I�ȏ���

                MemoUI[4].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari3_Got);
                break;

            case EventStatus.Zasso:
                // �����ɉ��o�I�ȏ���

                script.SetEvent(EventStatus.Zasso_Got); // �G��������
                break;
                // �ǂ�ǂ��ǂ�ǂ񂱂��ɃA�C�e���̏����ǉ�
        }
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
        }
    }

}

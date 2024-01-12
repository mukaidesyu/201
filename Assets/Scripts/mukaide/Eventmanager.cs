using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventmanager : MonoBehaviour
{
    public GameObject[] MemoUI;
    TreasureCount treasure;

    ItemgetUI itemUI;
    Live2D.Cubism.Framework.Expression.CubismExpressionController face;

    //�L�����ɌĂ�łق����֐�(�^�C���̃C�x���g�t���O�������Ă��̂��Ƃ�����)
    //�����炢���ȓ����ǉ����Ă�������҂��ĂĂق����Ƃ肠�����ō����
    public void Event(GameObject eventTile) // �����C�x���g�̎��
    {
        Tilemanager script = eventTile.GetComponent<Tilemanager>();
        switch (script.GetEvent())// �C�x���g���e���X�C�b�`������
        {
            // �o���R���̃A�C�e��***********************************
            case EventStatus.Kinoko:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(0);
                face.FaceChange(1);
                // �擾��ԂɕύX
                MemoUI[0].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kinoko_Got);
                treasure.TreasurePlus();
                break;

            case EventStatus.Sakana:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(1);
                face.FaceChange(1);
                MemoUI[1].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Sakana_Got);
                treasure.TreasurePlus();
                break;
            case EventStatus.Kari1:
                treasure.TreasurePlus();
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(2);
                face.FaceChange(1);
                MemoUI[2].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari1_Got);
                break;

            case EventStatus.Kari2:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(3);
                face.FaceChange(1);
                MemoUI[3].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari2_Got);
                treasure.TreasurePlus();
                break;
            case EventStatus.Kari3:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(4);
                face.FaceChange(1);
                MemoUI[4].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Kari3_Got);
                treasure.TreasurePlus();
                break;

            case EventStatus.Zasso:
                // �����ɉ��o�I�ȏ���
                script.SetEvent(EventStatus.Zasso_Got); // �G��������
                break;

            // �A�T�ΔȂ̃A�C�e��***********************************
            case EventStatus.Bread:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(5);
                face.FaceChange(1);
                // �擾��ԂɕύX
                MemoUI[0].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Bread_Got);
                treasure.TreasurePlus();
                break;

            case EventStatus.Egg:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(6);
                face.FaceChange(1);
                // �擾��ԂɕύX
                MemoUI[1].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Egg_Got);
                treasure.TreasurePlus();
                break;

            case EventStatus.Milk:
                // �����ɉ��o�I�ȏ���
                itemUI.SwitchItemGetStart(7);
                face.FaceChange(1);
                // �擾��ԂɕύX
                MemoUI[2].GetComponent<Memo_UI>().SetIsGet(true);
                script.SetEvent(EventStatus.Milk_Got);
                treasure.TreasurePlus();
                break;
                // �ǂ�ǂ��ǂ�ǂ񂱂��ɃA�C�e���̏����ǉ�
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        treasure = GameObject.Find("UI_TreasureCount").GetComponent<TreasureCount>();
        itemUI = GameObject.Find("ItemGet").GetComponent<ItemgetUI>();
        face = GameObject.Find("ririachan2").GetComponent<Live2D.Cubism.Framework.Expression.CubismExpressionController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}

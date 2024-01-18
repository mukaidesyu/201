using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum IrisFade
{
    None = 0,
    FadeIn,
    FadeOut,
}

public class CanvasManagerScript : MonoBehaviour
{
    bool isClear;
    bool canvasSet;
    GameObject gameCanvas;
    GameObject clearCanvas;
    GameObject nikukyuuCanvas;
    GameBGMManager bgm;

    GameObject nekoShot;
    IrisShot2 iris;
    IrisFade fadeState;

    int tmpTeasure; // ��U�A�擾�H�ނ�ۑ�

    // Start is called before the first frame update
    void Start()
    {
        bgm = GameObject.Find("Main Camera").GetComponent<GameBGMManager>();
        isClear = false;
        canvasSet = false;
        gameCanvas = this.transform.GetChild(0).gameObject;
        clearCanvas = this.transform.GetChild(1).gameObject;
        nikukyuuCanvas = this.transform.GetChild(2).gameObject;
        clearCanvas.SetActive(false);

        // �A���X�C���t�F�[�h���A�N�e�B�u��
        GameObject unmask = GameObject.Find("Unmask");
        iris = unmask.GetComponent<IrisShot2>();
        nekoShot = GameObject.Find("NekoShot");
        nekoShot.SetActive(false);

        // �t�F�[�h�̏�Ԃ�������
        fadeState = IrisFade.None;
        tmpTeasure = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            if (canvasSet == false)
            {
                // �^���ÂɂȂ������Ƃ̏��� ���ʂ�
                DrawClearCanvas();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            iris.IrisIn();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            iris.IrisOut();
        }
    }

    public void SetClear(bool set)
    {
        if (isClear == true) return;

        isClear = set;
        //nikukyuuCanvas.GetComponent<NikukyuuManager>().NikukyuuFadeStart();
    }

    public void DrawClearCanvas()
    {
        // �t�F�[�h���͏������Ȃ�
        if (iris.GetIsFade() == true) return;

        switch (fadeState)
        {
            case IrisFade.None:
                // �N���A�J�n�����ڂȂ�
                nekoShot.SetActive(true);
                iris.IrisOut();
                fadeState = IrisFade.FadeOut;
                tmpTeasure = GameObject.Find("UI_TreasureCount").GetComponent<TreasureCount>().GetTreasureCount();
                break;

            case IrisFade.FadeOut:
                // �N���A�L�����o�X���o��
                clearCanvas.SetActive(true);
                int tmp = GameObject.Find("TurnNumber").GetComponent<TurnScript>().GetTurn();
                GameObject.Find("ClearTurnNumber").GetComponent<ClearTurnScript>().SetTurn(tmp);          
                // ���ς���
                bgm.StartBGM();
                // �C�����ď�ԕύX
                iris.IrisIn();
                Debug.Log("����");
                fadeState = IrisFade.FadeIn;
                break;

            case IrisFade.FadeIn:
                // �N���A���o�J�n
                GameObject.Find("getitem").GetComponent<GetItemClear>().ClearStart();
                // ���͊e��ϐ����N���A��ʂɓn��������
                gameCanvas.SetActive(false);// �Q�[���L�����o�X������
                GameObject.Find("Neko").GetComponent<NekoOff>().NekoStop();
                GameObject.Find("GameObject").SetActive(false); // �Q�[���I�u�W�F�N�g������
                // �t�F�[�h��Ԃ̌�Еt��
                fadeState = IrisFade.None;
                // �N���A��ԂɕύX����
                canvasSet = true;
                // �N���A�A�C�e���擾����n��
                GameObject.Find("Food").GetComponent<Total>().SetTreaureCount(tmpTeasure);
                break;
        }
    }
}

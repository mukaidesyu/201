using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fade;//�C���X�y�N�^����Prefab������Canvas������
    public GameObject fadeCanvas;//���삷��Canvas�A�^�O�ŒT��

    void Start()
    {
        if (!FadeManager.isFadeInstance)//isFadeInstance�͌�ŗp�ӂ���
        {
            Instantiate(fade);
        }
        Invoke("findFadeObject", 0.02f);//�N�����p��Canvas�̏�����������Ƒ҂�
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvas���݂���
        fadeCanvas.GetComponent<FadeManager>().fadeIn();//�t�F�[�h�C���t���O�𗧂Ă�
    }

    public async void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();//�t�F�[�h�A�E�g�t���O�𗧂Ă�
        await Task.Delay(200);//�Ó]����܂ő҂�
        //SceneManager.LoadScene("mukaide");���ǂ���
        SceneManager.LoadScene(sceneName);//�V�[���`�F���W
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fade;//インスペクタからPrefab化したCanvasを入れる
    public GameObject fadeCanvas;//操作するCanvas、タグで探す
    GameObject nikukyuuManager; // 肉球フェードのマネージャーを入れる

    void Start()
    {
        if (!FadeManager.isFadeInstance)//isFadeInstanceは後で用意する
        {
            Instantiate(fade);
        }
        Invoke("findFadeObject", 0.02f);//起動時用にCanvasの召喚をちょっと待つ
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvasをみつける
        fadeCanvas.GetComponent<FadeManager>().fadeIn();//フェードインフラグを立てる
        nikukyuuManager = GameObject.Find("NikukyuuManager");//肉球フェードを取得
    }

    public async void sceneChange(string sceneName)//ボタン操作などで呼び出す
    {
        Time.timeScale = 1;
        fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
        nikukyuuManager.GetComponent<NikukyuuManager>().NikukyuuFadeStart();
        await Task.Delay(200);//暗転するまで待つ
        SceneManager.LoadScene(sceneName);//シーンチェンジ
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}

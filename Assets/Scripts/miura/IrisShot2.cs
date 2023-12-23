using UnityEngine;
using DG.Tweening;


public class IrisShot2 : MonoBehaviour
{
    [SerializeField] RectTransform unmask;

    readonly Vector2 IRIS_IN_SCALE = new Vector2(40, 40);
    readonly Vector2 IRIS_MID_SCALE1 = new Vector2(8.0f, 8.0f);
    readonly Vector2 IRIS_MID_SCALE2 = new Vector2(10.0f, 10.0f);
    bool isFade = false;

    public void IrisIn()
    {
        isFade = true;
        unmask.DOScale(IRIS_MID_SCALE2, 0.4f).SetEase(Ease.InCubic);
        unmask.DOScale(IRIS_MID_SCALE1, 0.2f).SetDelay(0.4f).SetEase(Ease.OutCubic);
        unmask.DOScale(IRIS_IN_SCALE, 0.2f).SetDelay(0.6f).SetEase(Ease.InCubic);

        Invoke("SetFalse",1.0f);
    }

    public void IrisOut()
    {
        isFade = true;
        unmask.DOScale(IRIS_MID_SCALE1, 0.2f).SetEase(Ease.InCubic);
        unmask.DOScale(IRIS_MID_SCALE2, 0.2f).SetDelay(0.2f).SetEase(Ease.OutCubic);
        unmask.DOScale(new Vector2(0, 0), 0.4f).SetDelay(0.4f).SetEase(Ease.InCubic);
        Invoke("SetFalse", 1.0f);
    }

    public bool GetIsFade()
    {
        return isFade;
    }

    void SetFalse()
    {
        isFade = false;
    }
}
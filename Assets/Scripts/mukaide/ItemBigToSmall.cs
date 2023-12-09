using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClearItemState
{
    None = 0,
    ToBig,
    ToSmall,
    Finish
}

public class ItemBigToSmall : MonoBehaviour
{
    RectTransform rect;
    [SerializeField]bool start = false;
    [SerializeField]ClearItemState state;
    int itemNo;
    float time;
    public float TimeMax = 1.0f;
    public float Big = 1.1f;
    public float Small = 1.005f;
    bool isGet;

    // Start is called before the first frame update
    void Start()
    {
        state = ClearItemState.None;
        rect = this.GetComponent<RectTransform>();
        time = TimeMax;
    }

    private void FixedUpdate()
    {
        if (start == false) return;
        if (state == ClearItemState.Finish) return;
        if (isGet == false) state = ClearItemState.Finish;

        switch (state)
        {
            case ClearItemState.None:// スタート
                state = ClearItemState.ToBig;
                break;
            case ClearItemState.ToBig:
                time -= Time.deltaTime;
                rect.localScale *= Big;
                if(time < 0)
                {
                    state = ClearItemState.ToSmall;
                    time = TimeMax;
                }
                break;
            case ClearItemState.ToSmall:
                time -= Time.deltaTime;
                rect.localScale /= Small;
                if (time < 0)
                {
                    state = ClearItemState.Finish;
                    time = TimeMax;
                }
                break;
            case ClearItemState.Finish:
                break;
        }
    }

    public void StartEffect()
    {
        start = true;
    }

    public ClearItemState GetState()
    {
        return state;
    }

    public void SetIsGet(bool set)
    {
        isGet = set;
    }
}

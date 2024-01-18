using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBigToSmall : MonoBehaviour
{
    RectTransform rect;
    bool start = false;
    ClearItemState state;
    float time;
    public float TimeMax = 1.0f;
    public float Big = 1.1f;
    public float Small = 1.005f;
    AudioSource audio;

    void Start()
    {
        state = ClearItemState.None;
        rect = this.GetComponent<RectTransform>();
        time = TimeMax;
        audio = GetComponent<AudioSource>();
        rect.localScale = new Vector3(0.045f, 0.045f, 0.045f);
    }

    private void FixedUpdate()
    {
        if (start == false) return;
        if (state == ClearItemState.Finish) return;

        switch (state)
        {
            case ClearItemState.None:// スタート
                // 音を1回だけ鳴らす
                audio.Play();
                state = ClearItemState.ToBig;
                break;
            case ClearItemState.ToBig:
                time -= Time.deltaTime;
                rect.localScale *= Big;
                if (time < 0)
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
                    ClearMeal mealScript = GameObject.Find("mojiMeal").GetComponent<ClearMeal>();
                    mealScript.GoAppear();

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
}

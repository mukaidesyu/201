using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearTurnScript : MonoBehaviour
{
    enum TurnState
    {
        None = 0,
        Start,
        Finish
    }

    // 経過ターン
    int turn;
    TextMeshProUGUI tmp;

    // どぅるどぅるする用
    bool effectFinish; //どぅるどぅる終わったかどうか
    public float EffectTime = 2.0f; // どぅるどぅるする時間
    int nowTurn;
    float oneTime = 0;
    float initTime = 0;
    TurnState state;

    // Start is called before the first frame update
    void Start()
    {
        effectFinish = true;
        tmp = this.GetComponent<TextMeshProUGUI>();
        nowTurn = 0;
        state = TurnState.None;
        tmp.text = nowTurn.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (effectFinish) return;
        if (state == TurnState.Finish) return;

        switch (state)
        {
            case TurnState.None:
                state = TurnState.Start;
                break;
            case TurnState.Start:
                if (turn > nowTurn)
                {
                    oneTime -= Time.deltaTime;
                    if (oneTime <= 0)
                    {
                        nowTurn++;
                        tmp.text = nowTurn.ToString("0");
                        oneTime = initTime;
                    }
                }
                else
                {
                    state = TurnState.Finish;
                    GameObject.Find("Food").GetComponent<FoodBigToSmall>().StartEffect();
                    effectFinish = true;
                }
                break;
            case TurnState.Finish:
                
                break;
        }
    }

    public void TurnPlus()
    {
        turn++;
    }

    public void SetTurn(int set)
    {
        turn = set;
        oneTime = initTime = EffectTime / turn;
    }

    public int GetTurn()
    {
        return turn;
    }

    public void EffectStart()
    {
        effectFinish = false;
    }
}

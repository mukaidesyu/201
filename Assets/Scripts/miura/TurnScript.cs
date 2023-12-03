using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnScript : MonoBehaviour
{
    // 経過ターン
    int turn;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = turn.ToString("0");
    }

    public void TurnPlus()
    {
        turn++;
    }

    public void SetTurn(int set)
    {
        turn = set;
    }

    public int GetTurn()
    {
        return turn;
    }
}

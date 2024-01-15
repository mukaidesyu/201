using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TurnScript : MonoBehaviour
{
    // åoâﬂÉ^Å[Éì
    int turn = 0;
    int faceturn;
    TextMeshProUGUI tmp;
    Live2D.Cubism.Framework.Expression.CubismExpressionController face;

    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        faceturn = 0;
        tmp = this.GetComponent<TextMeshProUGUI>();
        face = GameObject.Find("ririachan2").GetComponent<Live2D.Cubism.Framework.Expression.CubismExpressionController>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = turn.ToString("0");
    }

    public void TurnPlus()
    {
        turn++;
        faceturn++;
        if (faceturn == 5)
        {
            faceturn = 0;
            face.FaceChange(2);
        }
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

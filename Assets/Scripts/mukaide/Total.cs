using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Total : MonoBehaviour
{
    public Image image;

    [SerializeField]
    public Sprite rankA;
    public Sprite rankB;
    public Sprite rankC;

    ClearTurnScript turnScript;
    public int turn;

    private Animator anim;

    GetItemClear itemcs;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        turnScript = GameObject.Find("ClearTurnNumber").GetComponent<ClearTurnScript>();
        itemcs = GameObject.Find("getitem").GetComponent<GetItemClear>();

        anim = gameObject.GetComponent<Animator>();

        turn = turnScript.GetTurn();
    }

    // Update is called once per frame
    void Update()
    {
        turn = turnScript.GetTurn();
        if (turn <= 10)
        {
            anim.SetBool("max", true);
        }
        else if (turn > 10 && turn <= 20)
        {
            image.sprite = rankB;
        }
        else if (turn > 20)
        {
            anim.SetBool("bad", true);
        }
    }
}

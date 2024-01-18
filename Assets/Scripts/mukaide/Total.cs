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

    // ランクAのターン数
    public int rankATurn;
    public int rankAItem;

    // ランクBのターン数
    public int rankBTurn;
    public int rankBItem;

    bool toMealMoji;

    ClearTurnScript turnScript;
    public int turn;
    int treasureCount;

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
        treasureCount = 0;
        toMealMoji = false;
    }

    // Update is called once per frame
    void Update()
    {
        turn = turnScript.GetTurn();

        if (turn <= rankATurn && treasureCount >= rankAItem)
        {
            anim.SetBool("max", true);
            if(toMealMoji == false) 
            {
                GameObject.Find("mojiMeal").GetComponent<ClearMeal>().SetRank(1);
                toMealMoji = true;
            }
            
        }
        else if (turn > rankATurn && turn <= rankBTurn && treasureCount >= rankBItem) // ランクB
        {
            image.sprite = rankB;
            if (toMealMoji == false)
            {
                GameObject.Find("mojiMeal").GetComponent<ClearMeal>().SetRank(2);
                toMealMoji = true;
            }
        }
        else if (turn > rankBTurn && treasureCount >= rankAItem) // 特別に何ターンかかっても、食材を全部集めたらランクB
        {
            image.sprite = rankB;
            if (toMealMoji == false)
            {
                GameObject.Find("mojiMeal").GetComponent<ClearMeal>().SetRank(2);
                toMealMoji = true;
            }
        }
        else
        {
            anim.SetBool("bad", true);
            if (toMealMoji == false)
            {
                GameObject.Find("mojiMeal").GetComponent<ClearMeal>().SetRank(3);
                toMealMoji = true;
            }
        }

        //元のやつ
        //if (turn <= 10)
        //{
        //    anim.SetBool("max", true);
        //}
        //else if (turn > 10 && turn <= 20)
        //{
        //    image.sprite = rankB;
        //}
        //else if (turn > 20)
        //{
        //    anim.SetBool("bad", true);
        //}
    }

    public void SetTreaureCount(int set) 
    {
        treasureCount = set;
    }
}

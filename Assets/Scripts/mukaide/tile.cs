using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    [SerializeField] private GameObject _tile;
    public int _rows = 3;
    public int _cols = 3;
    private int i = 0;

    Rigidbody rb;

    // 生成したタイル全部のリスト
    List<GameObject> cd = new List<GameObject>();

    private void Awake()
    {
        for (int row = -5; row < _rows -5; row++)
        {
            for (int col = -5; col < _cols -5; col++)
            {
                _tile.name = "panel" + i;
                // タイルにIDを設定する
                _tile.GetComponent<Tilemanager>().SetTileNo(i);

                //パネルの生成
                Instantiate(_tile, new Vector3(row,0, col),
                    Quaternion.Euler(90, 0, 0), transform);
                i++;
            }
        }

    }
    private void Start()
    {
        for(int j = 0;j < i;j++)
        {
            cd.Add(transform.GetChild(j).gameObject);
            if(j <= 0)
            {
                cd[j].GetComponent<Tilemanager>().Startpanel();
            }
            if(j == i-1)
            {
                cd[j].GetComponent<Tilemanager>().Goalpanel();
                // 猫にゴールのタイルを渡す
                GameObject.Find("Neko").GetComponent<Neko_NavMesh>().SetGoal(cd[j]);
            }
        }

        //Rigidbodyの取得
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

    }

    // 縦横のゲッターとセッター
    public int GetRows()
    {
        return _rows;
    }
    public int GetCols()
    {
        return _cols;
    }

    // 被ったピースをなんかいっこ返す
    public GameObject GetOnTile()
    {
        List < GameObject > tmp = new List<GameObject>();
        int trueCount = 0;
        for (int j = 0; j < i; j++)
        {
            // タイルが被ってるか判断
            if(cd[j].GetComponent<Tilemanager>().GetOnTile() == true)
            {
                tmp.Add(cd[j].gameObject);
                trueCount++;
            }
        }


        // 被ったタイルの中からランダムで1つ引き渡す
        if(trueCount <= 0) return null;
        int rand = Random.Range(1, trueCount);
        return tmp[rand - 1].gameObject;

        // ↑もしかしてリストのdeleteいらない？？
    }

    // 置いたピースの中で1番遠いピースを返す
    public GameObject GetFarTile(GameObject onTile) // 引数：1つに決めた後の被ったピース
    {
        List<GameObject> tmp = new List<GameObject>();
        for (int j = 0; j < i; j++)
        {
            // 今置いたタイル全てを取得
            if (cd[j].GetComponent<Tilemanager>().GetNowPut() == true)
            {
                tmp.Add(cd[j].gameObject);
            }
        }

        GameObject farTile = tmp[0].gameObject;

        for (int j = 1; j < tmp.Count ;j++)
        {
            // 今1番遠いタイルより今びのタイルが遠かったら
            if (Vector3.Distance(farTile.transform.position,onTile.transform.position)
                < Vector3.Distance(tmp[j].transform.position, onTile.transform.position))
            {
                farTile = tmp[j].gameObject;// 入れ替え
            }
            else if (Vector3.Distance(farTile.transform.position, onTile.transform.position)
                == Vector3.Distance(tmp[j].transform.position, onTile.transform.position)) // 一緒だったら50%で入れ替え
            {
                int rand = Random.Range(0, 1);
                if(rand == 0)
                {
                    farTile = tmp[j].gameObject;
                }
            }
        }

        return farTile.gameObject;
    }


    // 全部のタイルを今置いてないフラグにする
    public void EndNowPut()
    {
        for (int j = 0; j < i; j++)
        {
            if (cd[j].GetComponent<Tilemanager>().GetNowPut() == true)
            {
                cd[j].GetComponent<Tilemanager>().SetNowPut(false);
            }

            if (cd[j].GetComponent<Tilemanager>().GetOnTile() == true)
            {
                cd[j].GetComponent<Tilemanager>().SetOnTile(false);
            }
        }

    }
}

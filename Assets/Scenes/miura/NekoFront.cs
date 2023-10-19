using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoFront : MonoBehaviour
{
    //
    GameObject frontPanel;
    [SerializeField]private bool walkFront;

    // Start is called before the first frame update
    void Start()
    {
        // スタート時、NekoFrontは見えなくなる
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerStay(Collider other)
    {// 猫の前のパネルを取得する
    // パネルのタグをパネルにした
        if (other.tag == "Panel")
        {
            bool tmp = other.GetComponent<Tile_select>().IsWalk;
            walkFront = tmp; // 前が歩けるかどうかを更新
            frontPanel = other.gameObject;
        }

    }

    //  前のパネルが通れるか通れないかのみを返す変数
    public bool GetWalkFront()
    {
        return walkFront;
    }

    public void SetWalkFront(bool val)
    {
        walkFront = val;
    }

    //  前のパネルのオブジェクトを返すす変数
    public GameObject GetFrontPanel()
    {
        return frontPanel;
    }
}

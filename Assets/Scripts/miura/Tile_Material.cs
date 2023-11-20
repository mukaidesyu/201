// パネルのスプライトを変更するスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Material : MonoBehaviour
{
    enum TileStatus
    {
        Grass = 0,
        Up,
        Left,
        Down,
        Right,
        Warm,
        Side,
    };

    Material[] tmp;
    TileStatus status;

    [SerializeField]Tilemanager UpPanel;
    [SerializeField]Tilemanager RightPanel;
    [SerializeField]Tilemanager LeftPanel;
    [SerializeField]Tilemanager DownPanel;

    [SerializeField]  private int id;

    public Material[] Materials;
    // Start is called before the first frame update
    void Start()
    {
        Material[] tmp = gameObject.GetComponent<Renderer>().materials;
        status = TileStatus.Grass;
        //タイルのid取得
        id = this.gameObject.GetComponent<Tilemanager>().GetTileNo();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material = Materials[(int)status];
    }

    // タイルが変更するたびに呼ぶといいかも
    public void SetMaterial(bool isWalk)
    {
        if (isWalk)
        {
            status = TileStatus.Up;
            // 上のパネルを取得
            if (id > 0)
<<<<<<< HEAD
            {  UpPanel = GameObject.Find("panel" + (id + 1) + "(Clone)"); status = TileStatus.Warm; }

=======
            {
                /*Debug.Log("通った");*/
                UpPanel = GameObject.Find("panel" + (id + 1) + "(Clone)").GetComponent<Tilemanager>();
                if (UpPanel.PutWalkFlag() == true)
                {
                    status = TileStatus.Warm;
                }
                RightPanel = GameObject.Find("panel" + (id + 11) + "(Clone)").GetComponent<Tilemanager>();
            }
>>>>>>> feature/Kenchan
        }
        else
        {
            status = TileStatus.Grass;
        }
    }
}

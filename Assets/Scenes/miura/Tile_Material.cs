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
        Right

    };

    Material[] tmp;
    TileStatus status;
    public Material[] Materials;
    // Start is called before the first frame update
    void Start()
    {
        Material[] tmp = gameObject.GetComponent<Renderer>().materials;
        status = TileStatus.Grass;
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
        }
        else
        {
            status = TileStatus.Grass;
        }


    }
}

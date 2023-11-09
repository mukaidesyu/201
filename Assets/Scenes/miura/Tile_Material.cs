// パネルのスプライトを変更するスクリプト
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Material : MonoBehaviour
{
    Material[] tmp;
    int idx;
    public Material[] Materials;
    // Start is called before the first frame update
    void Start()
    {
        Material[] tmp = gameObject.GetComponent<Renderer>().materials;
        idx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tmp[0] = Materials[idx];
        gameObject.GetComponent<Renderer>().materials = tmp;
    }

    public void SetMaterial(int no)
    {
        idx = no;
    }
}

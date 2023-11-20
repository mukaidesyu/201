// �p�l���̃X�v���C�g��ύX����X�N���v�g
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

    [SerializeField]GameObject UpPanel;

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

    // �^�C�����ύX���邽�тɌĂԂƂ�������
    public void SetMaterial(bool isWalk)
    {
        // �p�l����ID���擾
        int id = GetComponent<Tilemanager>().GetTileNo();

        // ��̃p�l�����擾
        if (id > 0) { UpPanel = GameObject.Find("panel" + (id++) + "(Clone)"); } 

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

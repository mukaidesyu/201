using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_select : MonoBehaviour
{
    public enum TileState
    {
       Select_None = 0,
       Select = 1,
       Select_Before 
    }

    [SerializeField] private TileState state;

    // Start is called before the first frame update
    void Start()
    {
        //�@�p�l�����o�鎞�ɂƂ肠�����������A�K�v���H
        
    }

    // Update is called once per frame
    void Update()
    {
        // �p�l���̏�Ԃɂ���ĐF���ς��
        switch (state)
        {
            case TileState.Select_None:
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
            case TileState.Select:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case TileState.Select_Before:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
}

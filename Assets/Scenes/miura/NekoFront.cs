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
        // �X�^�[�g���ANekoFront�͌����Ȃ��Ȃ�
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerStay(Collider other)
    {// �L�̑O�̃p�l�����擾����
    // �p�l���̃^�O���p�l���ɂ���
        if (other.tag == "Panel")
        {
            bool tmp = other.GetComponent<Tile_select>().IsWalk;
            walkFront = tmp; // �O�������邩�ǂ������X�V
            frontPanel = other.gameObject;
        }

    }

    //  �O�̃p�l�����ʂ�邩�ʂ�Ȃ����݂̂�Ԃ��ϐ�
    public bool GetWalkFront()
    {
        return walkFront;
    }

    public void SetWalkFront(bool val)
    {
        walkFront = val;
    }

    //  �O�̃p�l���̃I�u�W�F�N�g��Ԃ����ϐ�
    public GameObject GetFrontPanel()
    {
        return frontPanel;
    }
}

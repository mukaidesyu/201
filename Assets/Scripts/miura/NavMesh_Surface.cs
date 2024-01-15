using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavMesh_Surface : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        // ���̏����̓^�C�����o�����ォ���`
        Bake();
    }

    // Update is called once per frame
    void Update()
    {
        // ����\�����f

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Bake();
        }

    }

    // �i�r���b�V����Bulid�֐�
    public void Bake()
    {
        surface.BuildNavMesh();
    }
}

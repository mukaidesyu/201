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
        // この処理はタイルを出した後かも～
        Bake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Bake();
        }

    }

    // ナビメッシュのBulid関数
    public void Bake()
    {
        surface.BuildNavMesh();
    }
}

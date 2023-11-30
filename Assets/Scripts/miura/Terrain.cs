using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    Material wood;
    Material grass;
    bool KeyDown;
    public float returnTime;
    void Start()
    {
        wood = (Material)Resources.Load("Terrein/Prefabs/Default");
        grass = (Material)Resources.Load("Terrein/Prefabs/branch_tex");
        wood.color = new Color(0.7f, 0.5f, 0.3f, 1);
       
        KeyDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            KeyDown = true;

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            KeyDown = false;
        }


        if (KeyDown)
        {
            wood.color = new Color(0.7f, 0.5f, 0.3f, 0.3f);
            grass.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            wood.color *= new Color(1, 1, 1, returnTime);
            grass.color *= new Color(1, 1, 1, returnTime);

            if (wood.color.a >= 1.0)
            {
                wood.color = new Color(0.7f, 0.5f, 0.3f, 1);
            }
            if (grass.color.a >= 1.0)
            {
                grass.color = new Color(1, 1, 1, 1);
            }
        }
    }
}

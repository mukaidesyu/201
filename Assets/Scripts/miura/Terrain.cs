using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    Material wood;
    Material woodLeaf;
    public Material grass;
    bool KeyDown;
    public float returnTime;
    void Start()
    {
        wood = (Material)Resources.Load("Terrein/Prefabs/Default");
        woodLeaf = (Material)Resources.Load("Terrein/Prefabs/branch_tex");
        grass = (Material)Resources.Load("Terrein/Prefabs/grassmesh");
        wood.color = new Color(0.7f, 0.5f, 0.3f, 1);
        grass.color = new Color(0.3299849f, 1, 0.09811316f, 1);
       
        KeyDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown("joystick button 1"))
        {
            KeyDown = true;

        }
        if (Input.GetKeyUp(KeyCode.C )|| Input.GetKeyUp("joystick button 1"))
        {
            KeyDown = false;
        }


        if (KeyDown)
        {
            wood.color = new Color(0.7f, 0.5f, 0.3f, 0.3f);
            woodLeaf.color = new Color(1, 1, 1, 0.5f);
            grass.color = new Color(0.3299849f, 1, 0.09811316f, 0.2f);
        }
        else
        {
            wood.color *= new Color(1, 1, 1, returnTime);
            woodLeaf.color *= new Color(1, 1, 1, returnTime);
            grass.color *= new Color(1, 1, 1, returnTime);

            if (wood.color.a >= 1.0)
            {
                wood.color = new Color(0.7f, 0.5f, 0.3f, 1);
            }
            if (woodLeaf.color.a >= 1.0)
            {
                woodLeaf.color = new Color(1, 1, 1, 1);
            }
            if (grass.color.a >= 1.0)
            {
                grass.color = new Color(0.3299849f, 1, 0.09811316f, 1);
            }
        }
    }

    public bool GetMagick()
    {
        return KeyDown;
    }
}

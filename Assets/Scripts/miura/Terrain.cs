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
        wood = (Material)Resources.Load("Terrein/bark01_bottom");
        grass = (Material)Resources.Load("Terrein/Grass");
        wood.color = new Color(1, 1, 1, 1);
        grass.color = new Color(1, 1, 1, 1);
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
            wood.color = new Color(1, 1, 1, 0.5f);
            grass.color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            wood.color *= new Color(1, 1, 1, returnTime);
            grass.color *= new Color(1, 1, 1, returnTime);

            if (wood.color.a >= 1.0)
            {
                wood.color = new Color(1, 1, 1, 1);
            }
            if (grass.color.a >= 1.0)
            {
                grass.color = new Color(1, 1, 1, 1);
            }
        }
    }
}

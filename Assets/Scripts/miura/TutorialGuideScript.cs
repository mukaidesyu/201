using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGuideScript : MonoBehaviour
{
    MeshRenderer mesh;
    Color startColor;
    float alpha;
    float plus;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        startColor = mesh.material.color;
        alpha = 1;
        plus = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        alpha += plus;
        if(alpha < 0.6f || alpha > 1.0f)
        {
            plus *= -1;
        }
        mesh.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGoal : MonoBehaviour
{
    Image image;
    float alpha;
    float plus;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        alpha = 1;
        plus = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        alpha += plus;
        if (alpha < 0.6f || alpha > 1.0f)
        {
            plus *= -1;
        }
        image.material.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}

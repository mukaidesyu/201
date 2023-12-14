using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum nekoSE
{
    Nyan1 = 0,
    Nyan2,
}

public class Neko_SE : MonoBehaviour
{
    AudioSource audio;
    public AudioClip nyan1;
    public AudioClip nyan2;

    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySE(nekoSE se)
    {
        switch (se)
        {
            case nekoSE.Nyan1:
                audio.PlayOneShot(nyan1);
                break;
            case nekoSE.Nyan2:
                audio.PlayOneShot(nyan2);
                break;
        }
    }
}

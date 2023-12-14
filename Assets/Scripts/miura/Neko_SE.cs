using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VOICE
{
    Nyan1 = 0,
    Nyan2,

    VOICE_MAX
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            audio.PlayOneShot(nyan1);
        }
    }
}

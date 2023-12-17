using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGMManager : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip clearBGM;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        clearBGM = Resources.Load<AudioClip>("BGM/clearBGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBGM()
    {
        audio.Stop();
        audio.volume = 1.0f;
        audio.clip = clearBGM;
        audio.Play();
  
    }
}

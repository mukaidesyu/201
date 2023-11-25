using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEenter : MonoBehaviour
{
    //再生箇所
    public AudioSource Audio;

    //効果音
    public AudioClip enter;//ピース置いた時の音

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //ピース置いた時の音
    public void EnterSE()
    {
        Audio.PlayOneShot(enter);
    }
}

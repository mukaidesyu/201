using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GensoShikaku : MonoBehaviour
{
    ParticleSystem blueCircle;
    ParticleSystem redCircle;
    GameObject panel;
    Tilemanager tilemanager;
    Terrain NekoShikaku;
    EventStatus panelEve;
    EventStatus panelEveOld;

    // Start is called before the first frame update
    void Start()
    {
        blueCircle = this.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        redCircle = this.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        panel = gameObject.transform.parent.gameObject;
        tilemanager = panel.GetComponent<Tilemanager>();
        panelEve = tilemanager.GetEvent();
        NekoShikaku = GameObject.Find("Neko").GetComponent<Terrain>();

        if (panelEve == EventStatus.Kinoko || panelEve == EventStatus.Sakana || panelEve == EventStatus.Kari1
                    || panelEve == EventStatus.Kari2 || panelEve == EventStatus.Kari3)
                {
                    blueCircle.Play();
                    redCircle.Stop();
             }

    }

    // Update is called once per frame
    void Update()
    {
    //    panelEve = tilemanager.GetEvent();
    //    if (NekoShikaku.GetMagick())
    //    {
            
    //        if (panelEveOld != panelEve)// まだ変わっていなければエフェクトを変える
    //        {
    //            if (panelEve == EventStatus.Kinoko || panelEve == EventStatus.Sakana || panelEve == EventStatus.Kari1
    //                || panelEve == EventStatus.Kari2 || panelEve == EventStatus.Kari3)
    //            {
    //                blueCircle.Play();
    //                redCircle.Stop();
    //            }
    //            panelEveOld = panelEve;
    //        }
            
    //    }
    //    else
    //    {
    //       blueCircle.Stop();
    //       redCircle.Stop();
    //       panelEveOld = EventStatus.None;
    //    }
    }
}

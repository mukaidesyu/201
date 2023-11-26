using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    Sprite now;
    EventStatus EventSta;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        now = sprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        // ó·äOçXêVîªíË
        if (now != sprite[(int)EventSta])
        {
            now = sprite[(int)EventSta];

            switch (EventSta)
            {
                case EventStatus.None:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Juel:
                    Debug.Log("osu");
                    spriteRenderer.sprite = now;

                    break;
                case EventStatus.Juel_Got:
                    spriteRenderer.sprite = now;
                    break;
            }
        }
    }

    public void SetEventSta(EventStatus status)
    {
        EventSta = status;
    }
}

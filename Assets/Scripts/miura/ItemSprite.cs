using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    Sprite now;
    EventStatus EventSta;
    Animator grass;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        now = sprite[0];
        grass = GetComponent<Animator>();
        grass.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 例外更新判定
        if (now != sprite[(int)EventSta])
        {
            now = sprite[(int)EventSta];
            grass.enabled = false;
            switch (EventSta)
            {
                case EventStatus.None:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kinoko:
                    grass.enabled = true; // 動く草アニメーション起動
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kinoko_Got:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Sakana:
                    grass.enabled = true;
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Sakana_Got:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kari1:
                    grass.enabled = true;
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kari1_Got:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kari2:
                    grass.enabled = true;
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kari2_Got:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kari3:
                    grass.enabled = true;
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Kari3_Got:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Rock:
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Zasso:
                    grass.enabled = true;
                    spriteRenderer.sprite = now;
                    break;
                case EventStatus.Zasso_Got:
                    spriteRenderer.sprite = now;
                    grass.enabled = false;
                    spriteRenderer.enabled = false;
                    break;
            }
        }
    }

    public void SetEventSta(EventStatus status)
    {
        EventSta = status;
    }
}

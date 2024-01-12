using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventStatus // イベントの種類
{
    None = 0,
    Kinoko,
    Kinoko_Got,
    Sakana,
    Sakana_Got,
    Kari1,
    Kari1_Got,
    Kari2,
    Kari2_Got,
    Kari3,
    Kari3_Got,
    Rock,
    Ike,
    Zasso,
    Zasso_Got,
    Bread,
    Bread_Got,
    Egg,
    Egg_Got,
    Milk,
    Milk_Got,
    Egg2,
    Egg2_Got,
    Milk2,
    Milk2_Got,
    Pasta,
    Pasta_Got,
    Kinoko2,
    Kinoko2_Got,
    // 追加した場合,Itemプレハブのスプライトも追加しないとNuる。

    EventMax
}

public enum PanelStatus // パネルの状態
{
    Nothing = 0,
    CantWalk,
    Walkable
}
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
    // 追加した場合,Itemプレハブのスプライトも追加しないとNuる。

    EventMax
}

public enum PanelStatus // パネルの状態
{
    Nothing = 0,
    CantWalk,
    Walkable
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventStatus // イベントの種類
{
    None = 0,
    Juel,
    Juel_Got,

    EventMax
}

public enum PanelStatus // パネルの状態
{
    Nothing = 0,
    CantWalk,
    Walkable
}
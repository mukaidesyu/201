using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventStatus // �C�x���g�̎��
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
    // �ǉ������ꍇ,Item�v���n�u�̃X�v���C�g���ǉ����Ȃ���Nu��B

    EventMax
}

public enum PanelStatus // �p�l���̏��
{
    Nothing = 0,
    CantWalk,
    Walkable
}
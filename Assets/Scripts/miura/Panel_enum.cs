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
    // �ǉ������ꍇ,Item�v���n�u�̃X�v���C�g���ǉ����Ȃ���Nu��B

    EventMax
}

public enum PanelStatus // �p�l���̏��
{
    Nothing = 0,
    CantWalk,
    Walkable
}
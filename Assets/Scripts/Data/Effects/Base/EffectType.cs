using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    public enum EffectType
    {
        None = 0,
        Damage = 1,
        Heal = 1 << 1,
        BuffAtk = 1 << 2,
        DebuffAtk = 1 << 3,
        BuffDef = 1 << 4,
        DebuffDef = 1 << 5,
        BuffHp = 1 << 6,
        DebuffHp = 1 << 7,
        Destroy = 1 << 8,
        Freeze = 1 << 9,
        Stun = 1 << 10,
        Sick = 1 << 11,
        Poison = 1 << 12,
        Provision = 1 << 13
    }
}
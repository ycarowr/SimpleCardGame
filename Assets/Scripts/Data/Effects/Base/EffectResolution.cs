using SimpleCardGames.Data.Effects;
using SimpleCardGames;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public interface IEffectResolution
    {

    }

    public struct EffectResolution
    {
        public struct CharTemporaryStats
        {
            public int Health;
            public int Attack;
            public int Defense;
            public PlayerSeat Seat;
        }

        public CharTemporaryStats TemporaryStats { get; set; }
        public EffectType EffectType { get; set; }
        public int Amount { get; set; }
        public bool HasDefense { get; set; }
        public bool IsValid { get; set; }
        public bool IsLethal { get; set; }

        public EffectResolution(EffectType effectType = EffectType.None) : this()
        {
            IsValid = true;
            EffectType = effectType;
        }
    }
}
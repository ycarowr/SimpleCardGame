using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = "Data/Effect Set")]
    public class EffectsSet : ScriptableObject
    {
        public static EffectTriggerType[] AllTriggers =
        {
            EffectTriggerType.OnPlay,
            EffectTriggerType.OnPlayerStartTurn,
            EffectTriggerType.OnPlayerFinishTurn,
            EffectTriggerType.OnDraw,
            EffectTriggerType.OnDiscard
        };

        public static Dictionary<EffectTriggerType, string> AllTriggersByName =
            new Dictionary<EffectTriggerType, string>
            {
                {EffectTriggerType.OnPlayerStartTurn, "On Start Turn"},
                {EffectTriggerType.OnPlayerFinishTurn, "On Finish Turn"},
                {EffectTriggerType.OnDraw, "On Draw"},
                {EffectTriggerType.OnDiscard, "On Discard"},
                {EffectTriggerType.OnPlay, "On Play"}
            };

        [field: SerializeField] public EffectsByTrigger EffectsByTrigger { get; } = new EffectsByTrigger();
    }

    [Serializable]
    public class EffectsByTrigger : SerializableSortedDictionary<EffectTriggerType, ListEffects>
    {
    }

    [Serializable]
    public class ListEffects
    {
        public List<BaseEffectData> Effects = new List<BaseEffectData>();
    }
}
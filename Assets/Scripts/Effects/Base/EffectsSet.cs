using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace SimpleCardGame.Data.Effects
{
    [CreateAssetMenu(menuName ="Data/Effect Set")]
    public class EffectsSet : ScriptableObject
    {
        [SerializeField]
        private EffectsByTrigger effectsByTrigger = new EffectsByTrigger();
        public EffectsByTrigger EffectsByTrigger => effectsByTrigger;


        public static EffectTriggerType[] AllTriggers = new[]
        {
            EffectTriggerType.OnPlay,
            EffectTriggerType.OnPlayerStartTurn,
            EffectTriggerType.OnPlayerFinishTurn,
            EffectTriggerType.OnDraw,
            EffectTriggerType.OnDiscard,
        };

        public static Dictionary<EffectTriggerType, string> AllTriggersByName =
            new Dictionary<EffectTriggerType, string>()
            {
                {EffectTriggerType.OnPlayerStartTurn, "On Start Turn"},
                {EffectTriggerType.OnPlayerFinishTurn, "On Finish Turn"},
                {EffectTriggerType.OnDraw, "On Draw"},
                {EffectTriggerType.OnDiscard, "On Discard"},
                {EffectTriggerType.OnPlay, "On Play"}
            };
    }

    [Serializable]
    public class EffectsByTrigger : SerializableSortedDictionary<EffectTriggerType, ListEffects> { }

    [Serializable]
    public class ListEffects
    {
        public List<BaseEffectData> Effects = new List<BaseEffectData>();
    }
}
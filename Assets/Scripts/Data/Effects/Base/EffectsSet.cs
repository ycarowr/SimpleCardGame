using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    /// <summary>
    ///     It holds all the effects of a card. 
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Effect Set")]
    public class EffectsSet : ScriptableObject
    {
        [SerializeField] private EffectRegister register = new EffectRegister();
        public EffectRegister Register => register;

        /// <summary>
        ///     A register of effects organized by trigger type.
        ///     TODO: Evalute whether to keep or not the sorted dictionary.
        /// </summary>
        [Serializable]
        public class EffectRegister : SerializableSortedDictionary<EffectTriggerType, ListEffects>
        {
        }

        /// <summary>
        ///     Just a serializable list of effects.
        /// </summary>
        [Serializable]
        public class ListEffects
        {
            public List<BaseEffectData> Effects = new List<BaseEffectData>();
        }
    }
}
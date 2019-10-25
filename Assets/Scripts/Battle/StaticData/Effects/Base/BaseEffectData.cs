using SimpleCardGames.Data.Target;
using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    /// <summary>
    ///     Base class for all effects in the game.
    /// </summary>
    public abstract class BaseEffectData : ScriptableObject
    {
        public const string Path = "Data/Effect";

        //---------------------------------------------------------------------------------------------------------------------

        [SerializeField] [Tooltip("Quantity of the effect.")]
        int amount;
        //---------------------------------------------------------------------------------------------------------------------

        #region Fields

        //TODO: All these texts may be moved to a localization system and accessed via Ids.
        [Header("Data")]
        [SerializeField]
        [Tooltip("A brief description of what it does. This text won't be show to the user")]
        [Multiline]
        string description;

        #endregion

        [SerializeField] [Tooltip("Targets of this effect.")]
        BaseTargetType target;

        public int Amount => amount;
        public BaseTargetType Target => target;

        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Apply the effect into something which is able to take effects.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public abstract void Apply(ITargetable target, IEffectable source);
    }
}
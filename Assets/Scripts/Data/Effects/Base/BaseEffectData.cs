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

        #region Fields

        //TODO: All these texts may be moved to a localization system and accessed via Ids.
        [Header("Data")]
        [SerializeField] [Tooltip("A brief description of what it does. This text won't be show to the user")]
        [Multiline] private string description;
        [SerializeField] [Tooltip("Quantity of the effect.")] private int amount;
        #endregion

        //---------------------------------------------------------------------------------------------------------------------
        
        public int Amount => amount;

        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Apply the effect into something which is able to take effects.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public abstract void Apply(IEffectable target, RuntimeCard source);
    }
}
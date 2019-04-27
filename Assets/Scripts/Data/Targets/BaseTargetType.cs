using SimpleCardGames.Battle;
using SimpleCardGames.Data.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Data.Target
{
    public abstract class BaseTargetType : ScriptableObject
    {
        protected PlayerSeat PlayerSeat => PlayerSeat.Bottom;
        protected PlayerSeat OpponentSeat => PlayerSeat.Top;

        protected const string SOPath = "Data/Targets";

        [SerializeField] [Multiline] [Tooltip("Brief description of the target for internal purposes.")]
        private string description;

        /// <summary>
        ///     Returns all targets of this kind.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="gameData"></param>
        /// <returns></returns>
        public abstract IEffectable[] GetTargets(IEffector source, IPrimitiveGame gameData);
    }
}
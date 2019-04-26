using SimpleCardGames.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames
{ 
    /// <summary>
    ///     Abstract card at the runtime.
    /// </summary>
    public abstract class RuntimeCard : IRuntimeCard
    {
        protected RuntimeCard (ICardData data)
        {
            Data = data;
        }

        /// <summary>
        ///     Reference for all card data.
        /// </summary>
        public ICardData Data { get; }


        /// <summary>
        ///     Execution of the card when played.
        /// </summary>
        public abstract void Play();
    }
}

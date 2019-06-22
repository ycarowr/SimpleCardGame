using System;
using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    //--------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     RuntimeData stored inside the an UI card.
    /// </summary>
    public interface IUiCardData
    {
        IRuntimeCard RuntimeData { get; }
        ICardData StaticData { get; }
        Action<ICardData> OnSetData { get; set; }
        void SetData(IRuntimeCard card);
    }

    //--------------------------------------------------------------------------------------------------------------

    public class UiCardDataComponent : MonoBehaviour, IUiCardData
    {
        /// <summary>
        ///     Set a card.
        /// </summary>
        /// <param name="card"></param>
        public void SetData(IRuntimeCard card)
        {
            RuntimeData = card;
            OnSetData?.Invoke(StaticData);
        }

        /// <summary>
        ///     Static card data reference.
        /// </summary>
        public ICardData StaticData => RuntimeData.Data;

        /// <summary>
        ///     Fired when a card model is assigned to this card.
        /// </summary>
        public Action<ICardData> OnSetData { get; set; } = data => { };

        /// <summary>
        ///     Card correspondent in the game model.
        /// </summary>
        public IRuntimeCard RuntimeData { get; private set; }
    }
}
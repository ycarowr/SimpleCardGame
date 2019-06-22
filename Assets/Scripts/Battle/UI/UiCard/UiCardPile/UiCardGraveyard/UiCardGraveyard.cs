using System;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card graveyard holds a register with cards played by the player.
    /// </summary>
    public class UiCardGraveyard : UiCardPile
    {
        [SerializeField] [Tooltip("World point where the graveyard is positioned")]
        private Transform graveyardPosition;

        //--------------------------------------------------------------------------------------------------------------

        private IUiPlayerHand PlayerHand { get; set; }
        private ITargetResolver TargetResolver { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        protected override void Awake()
        {
            base.Awake();
            TargetResolver = transform.parent.GetComponentInChildren<ITargetResolver>();
            PlayerHand = transform.parent.GetComponentInChildren<IUiPlayerHand>();
            PlayerHand.OnCardDiscarded += AddCard;
            TargetResolver.OnTargetsResolve += AddCard;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Adds a card to the graveyard or discard pile.
        /// </summary>
        /// <param name="card"></param>
        public override void AddCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Add(card);
            card.transform.SetParent(graveyardPosition);
            card.Discard();
            NotifyPileChange();
        }


        /// <summary>
        ///     Removes a card from the graveyard or discard pile.
        /// </summary>
        /// <param name="card"></param>
        public override void RemoveCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);
            NotifyPileChange();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
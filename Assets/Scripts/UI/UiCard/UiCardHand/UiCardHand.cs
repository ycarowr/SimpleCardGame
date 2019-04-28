using SimpleCardGames;
using SimpleCardGames.Battle;
using SimpleCardGames.Battle.Controller;
using System;
using UnityEngine;

namespace Tools.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card Hand holds a register of cards.
    /// </summary>
    public class UiCardHand : UiCardPile, IUiCardHand
    {
        //--------------------------------------------------------------------------------------------------------------

        protected override void Awake()
        {
            base.Awake();
            Controller = GetComponent<IUiPlayer>();
        }

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        private IUiPlayer Controller { get; set; }

        /// <summary>
        ///     Card currently selected by the player.
        /// </summary>
        public IUiCard SelectedCard { get; private set; }

        private event Action<IUiCard> OnCardSelected = card => { };

        private event Action<IUiCard> OnCardPlayed = card => { };

        private event Action<IUiCard> OnCardDiscarded= card => { };

        /// <summary>
        ///     Event raised when a card is played.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardPlayed
        {
            get => OnCardPlayed;
            set => OnCardPlayed = value;
        }

        /// <summary>
        ///     Event raised when a card is selected.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardSelected
        {
            get => OnCardSelected;
            set => OnCardSelected = value;
        }

        /// <summary>
        ///     Event raised when a card is selected.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardDiscarded
        {
            get => OnCardDiscarded;
            set => OnCardDiscarded = value;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Select the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void SelectCard(IUiCard card)
        {
            if (card == null)
                return;

            SelectedCard = card;

            //disable all cards
            DisableCards();
            NotifyCardSelected();
        }

        /// <summary>
        ///     Play the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        /// <param name="card"></param>
        public void PlaySelected()
        {
            if (SelectedCard == null)
                return;

            PlayCard(SelectedCard);
        }

        /// <summary>
        ///     Play the card in the parameter. If can't unselect it.
        /// </summary>
        /// <param name="uiCard"></param>
        public void PlayCard(IUiCard uiCard)
        {
            if (uiCard == null)
                return;

            var card = uiCard.HandData.RuntimeCard;
            var isplayed = Controller.PlayerController.PlayCard(card);

            if(isplayed)
            {
                SelectedCard = null;
                RemoveCard(uiCard);
                OnCardPlayed?.Invoke(uiCard);
                EnableCards();
            } else
                Unselect();
        }

        /// <summary>
        ///     Discard the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void DiscardCard(IUiCard card)
        {
            if (card == null)
                return;

            RemoveCard(card);
            OnCardDiscarded?.Invoke(card);
            EnableCards();
        }

        /// <summary>
        ///     Unselect the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void UnselectCard(IUiCard card)
        {
            if (card == null)
                return;

            SelectedCard = null;
            card.Unselect();
            NotifyPileChange();
            EnableCards();
        }

        /// <summary>
        ///     Unselect the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        public void Unselect()
        {
            UnselectCard(SelectedCard);
        }

        /// <summary>
        ///     Disables input for all cards.
        /// </summary>
        public void DisableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Disable();
        }

        /// <summary>
        ///     Enables input for all cards.
        /// </summary>
        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        private void NotifyCardSelected()
        {
            OnCardSelected?.Invoke(SelectedCard);
        }

        public IUiCard GetCard(IRuntimeCard card)
        {
            return Cards.Find(x => x.HandData.Data == card.Data);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
using System;
using SimpleCardGames.Battle.UI.Character;

namespace SimpleCardGames.Battle.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card Hand holds a register of cards.
    /// </summary>
    public class UiPlayerHand : UiCardPile, IUiPlayerHand
    {
        //--------------------------------------------------------------------------------------------------------------

        protected override void Awake()
        {
            base.Awake();
            Controller = GetComponent<IUiPlayer>();
            TargetResolver = transform.parent.GetComponentInChildren<ITargetResolver>();
            PlayerTeams = transform.parent.parent.GetComponentsInChildren<IUiPlayerTeam>();
            foreach (var team in PlayerTeams)
            {
                team.OnPileChanged += (characters, capitain) => EnableCards();
                team.OnCharacterSelected += charac =>
                {
                    if (charac.IsUser) DisableCards();
                };
            }

            TargetResolver.OnTargetsResolve += card => EnableCards();
        }

        //------------------------------------------ --------------------------------------------------------------------

        #region Properties

        private ITargetResolver TargetResolver { get; set; }

        private IUiPlayerTeam[] PlayerTeams { get; set; }

        private IUiPlayer Controller { get; set; }

        public IUiCard SelectedCard { get; private set; }

        public Action<IUiCard> OnCardSelected { get; set; } = card => { };

        public Action<IUiCard> OnCardPlayed { get; set; } = card => { };

        public Action<IUiCard> OnCardDiscarded { get; set; } = card => { };

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

            var isMyTurn = Controller.PlayerController.IsMyTurn;
            var canPlayCost = Controller.PlayerController.Player.CanPlay(uiCard.Data.RuntimeData);

            if (!isMyTurn || !canPlayCost)
            {
                Unselect();
                return;
            }

            SelectedCard = null;
            RemoveCard(uiCard);
            OnCardPlayed?.Invoke(uiCard);
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
            return Cards.Find(x => x.Data.StaticData == card.Data);
        }

        public override void Restart()
        {
            base.Restart();
            SelectedCard = null;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
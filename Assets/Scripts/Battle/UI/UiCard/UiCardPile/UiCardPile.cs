using System;
using System.Collections.Generic;
using SimpleCardGames.Data.Card;

namespace SimpleCardGames.Battle.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Pile of cards. Add or Remove cards and be notified when changes happen.
    /// </summary>
    public abstract class UiCardPile : UiListener, IUiCardPile, IRestartGame
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        protected virtual void Awake()
        {
            //initialize register
            Cards = new List<IUiCard>();

            Restart();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        ///     List with all cards.
        /// </summary>
        public List<IUiCard> Cards { get; private set; }

        public Action<IUiCard[]> OnPileChanged { get; set; } = card => { };

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Add a card to the pile.
        /// </summary>
        /// <param name="card"></param>
        public virtual void AddCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Add(card);
            card.transform.SetParent(transform);
            card.Initialize();
            NotifyPileChange();
            card.Draw();
        }


        /// <summary>
        ///     Remove a card from the pile.
        /// </summary>
        /// <param name="card"></param>
        public virtual void RemoveCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);

            NotifyPileChange();
        }

        /// <summary>
        ///     Clear all the pile.
        /// </summary>
        [Button]
        public virtual void Restart()
        {
            var childCards = GetComponentsInChildren<IUiCard>();
            foreach (var uiCardHand in childCards)
                CardFactory.Instance.ReleasePooledObject(uiCardHand.gameObject);

            Cards.Clear();
        }

        /// <summary>
        ///     Notify all listeners of this pile that some change has been made.
        /// </summary>
        [Button]
        public void NotifyPileChange() => OnPileChanged?.Invoke(Cards.ToArray());

        void IRestartGame.OnRestart() => Restart();

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
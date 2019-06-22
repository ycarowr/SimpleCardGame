using System.Collections.Generic;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Deck;
using Tools;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class Library : Collection<IRuntimeCard>, ILibrary
    {
        private readonly IReadOnlyList<ICardData> cardDataRegister;

        //----------------------------------------------------------------------------------------------------------

        public Library(IPlayer player, LibraryData deckData, Configurations configurations)
        {
            if (deckData == null)
                Debug.LogError("A deck cant have null cards");

            Deck = deckData;
            Owner = player;
            Configurations = configurations;
            cardDataRegister = Deck.GetCards();
            CreateAndShuffle();
        }

        private Configurations Configurations { get; }
        private LibraryData Deck { get; }
        private IPlayer Owner { get; }
        public bool IsFinite => Configurations.Amount.LibraryPlayer.isFinite;

        /// <summary>
        ///     Draw the card on the top of the Library.
        /// </summary>
        /// <returns></returns>
        public IRuntimeCard DrawTop()
        {
            if (Size == 0)
            {
                if (!IsFinite)
                    ReShuffleGraveyard();

                if (Size == 0)
                    return null;
            }

            var card = GetLastAndRemove();
            return card;
        }

        /// <summary>
        ///     Create and adds a card to the Library based on the data.
        /// </summary>
        /// <param name="cardData"></param>
        public void AddCard(ICardData cardData)
        {
            var card = RuntimeCardFactory.Instance.Get();
            card.SetData(cardData);
            Add(card);
        }

        //----------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Creates and shuffle the Library based on the cards in the register.
        /// </summary>
        private void CreateAndShuffle()
        {
            foreach (var card in cardDataRegister)
                AddCard(card);

            Shuffle();
        }

        private void ReShuffleGraveyard()
        {
            foreach (var card in Owner.Graveyard.Units)
                Add(card);

            Owner.Graveyard.Clear();

            OnReShuffle(Owner);
        }

        private void OnReShuffle(IPlayer player)
        {
            GameEvents.Instance.Notify<IDoReShuffle>(i => i.OnReShuffle(player));
        }
    }
}
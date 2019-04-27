using System.Collections.Generic;
using SimpleCardGames.Data;
using SimpleCardGames.Data.Deck;
using Tools;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class Library : Collection<IRuntimeCard>, ILibrary
    {
        private readonly Collection<ICardData> cardRegister;
        public bool IsFinite => Configurations.Amount.LibraryPlayer.isFinite;

        //----------------------------------------------------------------------------------------------------------

        public Library(IPlayer player, BaseDeckData deckData, Configurations configurations)
        {
            if (deckData == null)
                Debug.LogError("A deck cant have null cards");

            Deck = deckData;
            Owner = player;
            Configurations = configurations;
            cardRegister = Deck.GetCards();
            CreateAndShuffle();
        }

        private Configurations Configurations { get; }
        private BaseDeckData Deck { get; }
        private IPlayer Owner { get; }

        /// <summary>
        ///     Draw the card on the top of the Library.
        /// </summary>
        /// <returns></returns>
        public IRuntimeCard DrawTop()
        {
            if (Size == 0)
            {
                if (!IsFinite)
                    CreateAndShuffle();
            }
            var card = GetLastAndRemove();
            Debug.Log("Drawn card: "+card.Data.CardName);
            return card;
        }

        /// <summary>
        ///     Create and adds a card to the Library based on the data.
        /// </summary>
        /// <param name="cardData"></param>
        public void AddCard(ICardData cardData)
        {
            Add(new RuntimeCard(cardData));
        }

        //----------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Creates and shuffle the Library based on the cards in the register.
        /// </summary>
        private void CreateAndShuffle()
        {
            Debug.Log("Library Created: " + Owner.Seat);
            foreach (var card in cardRegister.Units)
                AddCard(card);

            Shuffle();
            Debug.Log("Shuffled");
        }
    }
}
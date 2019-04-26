using SimpleCardGames.Data;
using SimpleCardGames.Data.Deck;
using SimpleCardGames;
using System;
using System.Collections.Generic;
using Tools;

namespace SimpleCardGames.Battle
{
    public class Library: Collection<IRuntimeCard>, ILibrary
    {
        Configurations Configurations { get; }
        private readonly List<ICardData> cardRegister;
        private BaseDeckData Deck { get; set; }
        private IBoard Board { get; set; }
        private IPlayer Owner { get; set; }

        //----------------------------------------------------------------------------------------------------------

        public Library(IPlayer player, BaseDeckData deck, IBoard board, Configurations configurations)
        {
            Deck = deck;
            Owner = player;
            Board = board;
            Configurations = configurations;
            cardRegister = Deck.GetCards();
            CreateAndShuffle();
        }

        //----------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Creates and shuffle a library based on the cards in the register.
        /// </summary>
        private void CreateAndShuffle()
        {
            foreach (var card in cardRegister)
                AddCard(card);

            Shuffle();
        }

        /// <summary>
        ///     Draw the card on the top of the Library.
        /// </summary>
        /// <returns></returns>
        public IRuntimeCard DrawTop()
        {
            if (Size == 0)
            {
                var isFinite = false;
                if (!isFinite)
                    CreateAndShuffle();
            }

            return GetLastAndRemove();
        }

        public void AddCard(ICardData cardData)
        {
            //new RuntimeCard
        }
    }
}
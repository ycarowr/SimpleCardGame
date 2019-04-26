using System.Collections.Generic;
using SimpleCardGames.Data;
using SimpleCardGames.Data.Deck;
using Tools;

namespace SimpleCardGames.Battle
{
    public class Library : Collection<IRuntimeCard>, ILibrary
    {
        private readonly List<ICardData> cardRegister;

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

        private Configurations Configurations { get; }
        private BaseDeckData Deck { get; }
        private IBoard Board { get; }
        private IPlayer Owner { get; }

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
    }
}
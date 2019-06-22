using System.Collections.Generic;
using System.Linq;
using Patterns;
using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    /// <summary>
    ///     Database that manages static card data.
    /// </summary>
    public class CardDatabase : Singleton<CardDatabase>
    {
        private const string PathDataBase = "Battle/CardDatabase";

        public CardDatabase()
        {
            if (Cards == null)
                Cards = Resources.LoadAll<CardData>(PathDataBase).ToList();
        }

        private List<CardData> Cards { get; }

        public CardData Get(CardId id)
        {
            return Cards?.Find(card => card.Id == id);
        }

        public List<CardData> GetFullList()
        {
            return Cards;
        }
    }
}
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
        const string PathDataBase = "Battle/CardDatabase";

        public CardDatabase()
        {
            if (Cards == null)
                Cards = Resources.LoadAll<CardData>(PathDataBase).ToList();
        }

        List<CardData> Cards { get; }

        public CardData Get(CardId id) => Cards?.Find(card => card.Id == id);

        public List<CardData> GetFullList() => Cards;
    }
}
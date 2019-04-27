using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleCardGames.Data
{
    public class CardFactory : PrefabPooler<CardFactory>
    {
        private CardDatabase Database { get; set; }

        protected override void OnAwake()
        {
            Database = new CardDatabase();
        }

        public GameObject Get(IRuntimeCard card)
        {
            var cardUi = Get(modelsPooled[0]);
            var handler = cardUi.GetComponent<ICardHandData>();
            handler.SetCard(card);
            return cardUi.gameObject;
        }

        private class CardDatabase
        {
            private const string PathDataBase = "CardDatabase";

            public CardDatabase()
            {
                Cards = Resources.LoadAll<CardData>(PathDataBase).ToList();
            }

            private List<CardData> Cards { get; }

            public CardData Get(CardId id)
            {
                return Cards?.Find(card => card.Id == id);
            }
        }
    }
}
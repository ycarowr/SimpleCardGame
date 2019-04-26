using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SimpleCardGames.Data.Deck
{
    [CreateAssetMenu(menuName = "Data/Deck")]
    public class BaseDeckData : ScriptableObject
    {
        [SerializeField] protected List<CardData> cards = new List<CardData>();

        [SerializeField] private bool forceReady;

        public List<ICardData> GetCards()
        {
            //new list with everything inside
            var allData = new List<ICardData>();
            cards.ForEach(characterData => allData.Add(characterData));
            return allData;
        }

        public virtual void Initialize() { }
    }
}

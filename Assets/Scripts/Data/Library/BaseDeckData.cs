using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace SimpleCardGames.Data.Deck
{
    [CreateAssetMenu(menuName = "Data/Deck")]
    public class BaseDeckData : ScriptableObject
    {
        [SerializeField] protected List<CardData> cards = new List<CardData>();

        public Collection<ICardData> GetCards()
        {
            //new list with everything inside
            var allData = new Collection<ICardData>();
            cards.ForEach(characterData => allData.Add(characterData));
            return allData;
        }
    }
}
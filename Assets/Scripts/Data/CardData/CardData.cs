using System.Collections.Generic;
using SimpleCardGames.Data.Effects;
using SimpleCardGames;
using UnityEngine;

namespace SimpleCardGames.Data
{
    [CreateAssetMenu(menuName = "Data/Card")] 
    public class CardData : ScriptableObject, ICardData
    {
        [SerializeField] private CardId id;
        [SerializeField] private CardType cardType;
        [SerializeField] private string cardName;
        [SerializeField] private string cardDescription;
        [SerializeField] private Sprite artwork;
        [SerializeField] private EffectsSet dataEffects;
                
        //--------------------------------------------------------------------------------------------------------------
        
        public CardId Id => id;
        public string CardName => cardName;
        public CardType CardType => cardType;
        public string CardDescription => cardDescription;
        public Sprite Artwork => artwork;
        public EffectsSet Effects => dataEffects;
        
    }
}
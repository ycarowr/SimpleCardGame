using System.Collections.Generic;
using SimpleCardGame.Data.Effects;
using SimpleTurnBasedGame;
using UnityEngine;

namespace SimpleCardGame.Data
{
    [CreateAssetMenu(menuName = "Data/Card")]
    public class CardData : ScriptableObject, ICardData
    {
        //--------------------------------------------------------------------------------------------------------------
                
        private const string Path = "CardDatabase";
        private static List<CardData> dataBase = new List<CardData>();
        [SerializeField] private CardId id;
        [SerializeField] private MoveType moveType;
        [SerializeField] private CardType cardType;
        [SerializeField] private string cardName;
        [SerializeField] private string cardDescription;
        [SerializeField] private Sprite artwork;
        [SerializeField] private EffectsSet dataEffects;
                
        //--------------------------------------------------------------------------------------------------------------
        
        public CardId Id => id;
        public string CardName => cardName;
        public CardType CardType => cardType;
        public MoveType MoveType => moveType;
        public string CardDescription => cardDescription;
        public Sprite Artwork => artwork;


        //--------------------------------------------------------------------------------------------------------------       

        private void OnEnable()
        {
            dataBase.Add(this);
        }
        
        
        //--------------------------------------------------------------------------------------------------------------
    }
}
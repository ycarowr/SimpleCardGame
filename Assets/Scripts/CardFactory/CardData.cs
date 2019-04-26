using System.Collections.Generic;
using System.Linq;
using SimpleTurnBasedGame;
using UnityEngine;

namespace SimpleCardGame
{
    [CreateAssetMenu(menuName = "CardData")]
    public class CardData : ScriptableObject
    {
        //--------------------------------------------------------------------------------------------------------------
        
        #region Fields 
        
        private const string Path = "CardDatabase";
        private static List<CardData> dataBase = new List<CardData>();
        [SerializeField] private CardId id;
        [SerializeField] private MoveType moveType;
        [SerializeField] private CardType cardType;
        [SerializeField] private string cardName;
        [SerializeField] private string cardDescription;
        [SerializeField] private Sprite artwork;
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Properties

        public CardId Id => id;
        public string CardName => cardName;
        public CardType CardType => cardType;
        public MoveType MoveType => moveType;
        public string CardDescription => cardDescription;
        public Sprite Artwork => artwork;

        #endregion

        //--------------------------------------------------------------------------------------------------------------       
        
        #region Unitycallbacks
        
        private void OnEnable()
        {
            dataBase.Add(this);
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
    }

    public enum CardId
    {
        Wizard,
        Chimera,
        Demon
    }

    public enum CardType
    {
        Human, 
        Beast,
        Demon
    }
}
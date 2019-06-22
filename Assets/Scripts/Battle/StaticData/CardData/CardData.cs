using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    [CreateAssetMenu(menuName = "Data/Card")]
    public class CardData : ScriptableObject, ICardData
    {
        [SerializeField] private Sprite artwork;
        [SerializeField] private int cardCost;
        [SerializeField] private CardMonsterType cardMonsterType;
        [SerializeField] private string cardName;
        [SerializeField] private CardRarity cardRarity;
        [SerializeField] private CardType cardType;
        [SerializeField] private EffectsSet dataEffects;
        [SerializeField] private string description;
        [SerializeField] private CardId id;

        //--------------------------------------------------------------------------------------------------------------

        public CardId Id => id;
        public int CardCost => cardCost;
        public CardType CardType => cardType;
        public CardMonsterType CardMonsterType => cardMonsterType;
        public CardRarity CardRarity => cardRarity;
        public string Name => cardName;
        public string Description => description;
        public Sprite Artwork => artwork;
        public EffectsSet Effects => dataEffects;
    }
}
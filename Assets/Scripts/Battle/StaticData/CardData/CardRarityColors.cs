using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    [CreateAssetMenu(menuName = "Data/CardRarity")]
    public class CardRarityColors : ScriptableObject
    {
        [SerializeField] private Color commonRarityColor;
        [SerializeField] private Color curseRarityColor;
        [SerializeField] private Color epicRarityColor;
        [SerializeField] private Color legendaryRarityColor;
        [SerializeField] private Color rareRarityColor;

        //--------------------------------------------------------------------------------------------------------------

        public Color CommonRarityColor => commonRarityColor;
        public Color RareRarityColor => rareRarityColor;
        public Color EpicRarityColor => epicRarityColor;
        public Color LegendaryRarityColor => legendaryRarityColor;
        public Color CurseRarityColor => curseRarityColor;
    }
}
using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject, ICharacterData
    {
        [SerializeField] Sprite artwork;
        [Range(1, 16)] [SerializeField] int attack;
        [Range(1, 16)] [SerializeField] int attacksTurn = 1;
        [SerializeField] string characterName;
        [Range(1, 16)] [SerializeField] int defense;
        [SerializeField] string description;
        [SerializeField] bool hasTaunt;

        [Range(1, 16)] [SerializeField] int health = 1;
        [SerializeField] CharacterId id;
        public int Defense => defense;

        //--------------------------------------------------------------------------------------------------------------

        public CharacterId Id => id;
        public string Name => characterName;
        public string Description => description;
        public Sprite Artwork => artwork;
        public int Health => health;
        public int Attack => attack;
        public int AttacksTurn => attacksTurn;
        public bool HasTaunt => hasTaunt;
    }
}
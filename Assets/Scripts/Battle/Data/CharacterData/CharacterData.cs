using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject, ICharacterData
    {
        [SerializeField] private Sprite artwork;
        [Range(1, 16)] [SerializeField] private int attack;
        [Range(1, 16)] [SerializeField] private int attacksTurn = 1;
        [SerializeField] private string characterName;
        [Range(1, 16)] [SerializeField] private int defense;
        [SerializeField] private string description;
        [SerializeField] private bool hasTaunt;

        [Range(1, 16)] [SerializeField] private int health = 1;
        [SerializeField] private CharacterId id;
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
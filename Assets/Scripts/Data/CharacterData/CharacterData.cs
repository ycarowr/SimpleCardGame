using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data.Character
{

    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject, ICharacterData
    {
        [Range(1, 16)] [SerializeField] private int health = 1;
        [SerializeField] private CharacterId id;
        [SerializeField] private string characterName;
        [SerializeField] private string description;
        [SerializeField] private Sprite artwork;

        //--------------------------------------------------------------------------------------------------------------

        public CharacterId Id => id;
        public int Health => health;
        public string Name => characterName;
        public string Description => description;
        public Sprite Artwork => artwork;
    }
}
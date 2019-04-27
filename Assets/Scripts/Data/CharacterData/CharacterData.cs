using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    public interface ICharacterData
    {
        int Health { get; }
        string Name { get; }
    }

    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject, ICharacterData
    {
        [Range(1, 16)] [SerializeField] private int health = 1;
        [SerializeField] string characterName;

        int ICharacterData.Health => health;
        string ICharacterData.Name => characterName;
    }
}
using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    [CreateAssetMenu(menuName = "Data/Character")]
    public class CharacterData : ScriptableObject
    {
        [Tooltip("Root of the Effects")] public EffectsSet Effects;

        [Range(1, 16)] public int Health;
    }
}
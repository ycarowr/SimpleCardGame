using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Spawn")]
    public class SpawnDataEffect : BaseEffectData
    {
        [SerializeField] [Tooltip("Character who will be spawned")]
        CharacterData characterData;

        public override void Apply(ITargetable target, IEffectable source)
        {
            var spawner = target as ISpawner;
            spawner.DoSpawn(Amount, characterData, source);
        }

        public CharacterData GetCharacterSpawnedFromEffect() => characterData;
    }
}
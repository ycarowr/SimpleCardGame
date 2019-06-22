using SimpleCardGames.Data.Character;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames
{
    /// <summary>
    ///     All units that are able to spawn other units.
    /// </summary>
    public interface ISpawner
    {
        /// <summary>
        ///     Spawn an amount of units.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        void DoSpawn(int amount, ICharacterData data, IEffectable source);
    }
}
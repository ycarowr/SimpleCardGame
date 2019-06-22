using SimpleCardGames.Data.Character;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Spawn mechanics.
    /// </summary>
    public class SpawnMechanics : BasePlayerMechanics
    {
        public SpawnMechanics(IPlayer player) : base(player)
        {
        }

        public void DoSpawn(int amount, ICharacterData data, IEffectable source)
        {
            var member = new RuntimeCharacter(data, Player);
            for (var i = 0; i < amount; i++)
                Player.Team.AddMember(member);

            OnSpawnCharacter(Player, member);
        }

        /// <summary>
        ///     Dispatch card spawn to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="character"></param>
        private void OnSpawnCharacter(IPlayer player, IRuntimeCharacter character)
        {
            GameEvents.Instance.Notify<IPlayerSpawnCharacter>(i => i.OnSpawnCharacter(player, character));
        }
    }
}
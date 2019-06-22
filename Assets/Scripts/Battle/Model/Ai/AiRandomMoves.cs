using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     This Ai always pick a random move.
    /// </summary>
    public class AiRandomMoves : AiBase
    {
        public AiRandomMoves(IPlayer player, IGame game) : base(player, game)
        {
        }

        public override AttackMechanics.RuntimeAttackData[] GetAttackMoves()
        {
            return GetAllAttackMoves();
        }

        protected AttackMechanics.RuntimeAttackData[] GetAllAttackMoves()
        {
            var playerTeam = Player.Team.Members;
            var enemyTeam = Enemy.Team.Members;
            var allAttacks = new List<AttackMechanics.RuntimeAttackData>();

            foreach (var agressor in playerTeam)
            {
                var possibilities = new List<AttackMechanics.RuntimeAttackData>();

                foreach (var defender in enemyTeam)
                {
                    var attack = new AttackMechanics.RuntimeAttackData
                    {
                        Agressor = agressor,
                        Blocker = defender
                    };

                    possibilities.Add(attack);
                }

                allAttacks.Add(possibilities.ToList().RandomItem());
            }

            return allAttacks.ToArray();
        }
    }
}
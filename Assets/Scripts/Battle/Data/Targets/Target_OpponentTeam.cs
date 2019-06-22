using SimpleCardGames.Battle;
using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data.Target
{
    /// <summary>
    ///     Effects which target ALL the Opponent's characters have to assign this SO to the target field.
    /// </summary>
    [CreateAssetMenu(menuName = SOPath + "/Opponent Team")]
    public class Target_OpponentTeam : BaseTargetType
    {
        public override ITargetable[] GetTargets(IEffectable source, IPrimitiveGame gameData)
        {
            //get player team
            var team = gameData.TurnLogic.GetPlayer(OpponentSeat).Team;

            var teamSize = team.Members.Count;

            //instantiate an array with the proper size
            var targets = new ITargetable[teamSize];

            //add all members to the target list
            for (var i = 0; i < teamSize; i++)
                targets[i] = team.GetMember(i);

            return targets;
        }
    }
}
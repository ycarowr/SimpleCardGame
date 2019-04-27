using SimpleCardGames.Battle;
using SimpleCardGames.Data.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Data.Target
{
    /// <summary>
    ///     Effects which target the Player have to assign this SO to the target field.
    /// </summary>
    [CreateAssetMenu(menuName = SOPath + "/Player")]
    public class Target_Player : BaseTargetType
    {
        public override IEffectable[] GetTargets(IEffector source, IPrimitiveGame gameData)
        {
            //get the player
            var player = gameData.TurnLogic.GetPlayer(PlayerSeat);

            //add it as a target
            var targets = new IEffectable[] { player };
            
            return targets;
        }
    }
}
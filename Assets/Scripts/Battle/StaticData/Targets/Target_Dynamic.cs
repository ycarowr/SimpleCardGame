using System.Collections.Generic;
using SimpleCardGames.Battle;
using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data.Target
{
    /// <summary>
    ///     It targets any of opponent's characters.
    /// </summary>
    [CreateAssetMenu(menuName = SOPath + "/Dynamic")]
    public class Target_Dynamic : BaseTargetType
    {
        readonly List<ITargetable> targets = new List<ITargetable>();
        [SerializeField] int targetAmount;
        public PlayerSeat TargetPlayer = PlayerSeat.Left;
        public override bool IsDynamic => true;
        public override int TargetAmount => targetAmount;

        public override ITargetable[] GetTargets(IEffectable source, IGame gameData) => targets.ToArray();

        void GetDynamicTarget(ITargetable target, PlayerSeat player)
        {
            if (player == TargetPlayer)
                targets.Add(target);
        }

        public override void Subscribe(ITargetResolver Resolver) => Resolver.OnSelectTarget += GetDynamicTarget;

        public override void Unsubscribe(ITargetResolver Resolver)
        {
            Resolver.OnSelectTarget -= GetDynamicTarget;
            targets.Clear();
        }
    }
}
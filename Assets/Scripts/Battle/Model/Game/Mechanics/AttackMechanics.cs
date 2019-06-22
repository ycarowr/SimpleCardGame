namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Attack Logic Implementation
    /// </summary>
    public class AttackMechanics : BaseGameMechanics
    {
        public AttackMechanics(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Execution of the damage logic.
        /// </summary>
        public void Execute(RuntimeAttackData data)
        {
            if (!Game.IsTurnInProgress)
                return;

            if (!Game.IsGameStarted)
                return;

            if (Game.IsGameFinished)
                return;

            //get attacker
            var attackerPlayer = Game.TurnLogic.GetPlayer(data.Agressor.Attributes.Owner.Seat);

            if (!Game.TurnLogic.IsMyTurn(attackerPlayer))
                return;

            var source = data.Agressor;
            var target = data.Blocker;
            var teamHasTaunt = data.Blocker.Attributes.Owner.Team.HasTaunt;
            var isTauntSelected = data.Blocker.Attributes.HasTaunt;

            if (!source.CanAttack() || !isTauntSelected & teamHasTaunt)
            {
                GameEvents.Instance.Notify<IDoAttack>(i => i.OnCantAttack(source, target, 0));
                return;
            }

            //apply effects that happen before an attack
            source.OnBeforeAttack();

            var damage = source.Attributes.Attack;

            //do attack
            var damageDealt = source.GiveDamage(target);

            //attack execution
            source.ExecuteAttack();

            //apply effects that happen after an attack
            source.OnAfterAttack();

            //dispatch damage
            OnDoneDamage(source, target, damageDealt);
        }

        /// Dispatch damage dealt to the listeners.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        private void OnDoneDamage(IRuntimeCharacter source, IRuntimeCharacter target, int amount)
        {
            GameEvents.Instance.Notify<IDoAttack>(i => i.OnDamage(source, target, amount));
        }

        public struct RuntimeAttackData
        {
            public IRuntimeCharacter Agressor { get; set; }
            public IRuntimeCharacter Blocker { get; set; }
        }
    }
}
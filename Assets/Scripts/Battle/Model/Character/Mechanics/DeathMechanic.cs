using SimpleCardGames.Battle.Controller;

namespace SimpleCardGames.Battle
{
    public class DeathMechanic : CharMechanic
    {
        public DeathMechanic(IRuntimeCharacter character) : base(character)
        {
        }

        public void EvaluateDeath()
        {
            if (!Attributes.IsDead)
                return;

            Attributes.Owner.Team.RemoveMember(Character);
            OnDeath(Attributes.Owner, Character);
            var finishGame = GetFinishGameMechanics();
            finishGame.CheckWinCondition();
        }

        private FinishGameMechanics GetFinishGameMechanics()
        {
            var mechanic =
                GameController.Instance.Data.RuntimeGame.Mechanics.Find(x =>
                    x.GetType() == typeof(FinishGameMechanics));
            return mechanic as FinishGameMechanics;
        }

        public void OnDeath(IPlayer Owner, IRuntimeCharacter target)
        {
            //Find player who owns target. remove from roster
            GameEvents.Instance.Notify<IDoKill>(i => i.OnKill(target));
        }
    }
}
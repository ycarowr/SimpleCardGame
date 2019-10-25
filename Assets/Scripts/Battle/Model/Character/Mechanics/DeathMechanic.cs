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
            GameController.Instance.Data.RuntimeGame.FinishGame.CheckWinCondition();
        }

        public void OnDeath(IPlayer Owner, IRuntimeCharacter target) =>
            GameEvents.Instance.Notify<IDoKill>(i => i.OnKill(target));
    }
}
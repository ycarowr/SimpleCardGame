namespace SimpleCardGames.Battle
{
    public class AttackCharacterMechanic : CharMechanic
    {
        public AttackCharacterMechanic(IRuntimeCharacter character) : base(character)
        {
            ResetAttackQuantity();
            AttacksThisTurn = Attributes.MaxAttackPerTurn;
        }

        public int AttacksThisTurn { get; private set; }

        public bool CanAttack() => AttacksThisTurn < Attributes.MaxAttackPerTurn;

        public void Execute() => AttacksThisTurn++;

        public void ResetAttackQuantity() => AttacksThisTurn = 0;

        public void OnBeforeAttack()
        {
        }

        public void OnAfterAttack()
        {
        }
    }
}
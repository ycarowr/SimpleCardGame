namespace SimpleCardGames.Battle
{
    public class AtkTrnMechanic : CharMechanic
    {
        public AtkTrnMechanic(IRuntimeCharacter character) : base(character)
        {
            ResetAttackQuantity();
            AttacksThisTurn = Attributes.MaxAttackPerTurn;
        }

        public int AttacksThisTurn { get; private set; }

        public bool CanAttack()
        {
            return AttacksThisTurn < Attributes.MaxAttackPerTurn;
        }

        public void Execute()
        {
            AttacksThisTurn++;
        }

        public void ResetAttackQuantity()
        {
            AttacksThisTurn = 0;
        }

        public void OnBeforeAttack()
        {
        }

        public void OnAfterAttack()
        {
        }
    }
}
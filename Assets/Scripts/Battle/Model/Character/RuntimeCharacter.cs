using SimpleCardGames.Data.Character;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete character in the game.
    /// </summary>
    public class RuntimeCharacter : IRuntimeCharacter
    {
        public IPlayer Owner { get; private set; }
        public IBoardPosition Position { get; set; }
        public ICharacterData Data { get; private set; }
        public CharAttributes Attributes { get; private set; }

        void IRuntimeCharacter.StartPlayerTurn()
        {
            Attributes.HasSummoningSickness = false;
            AttackTurn.ResetAttackQuantity();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Death

        public void EvaluateDeath()
        {
            Death.EvaluateDeath();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Mechanics

        private AtkTrnMechanic AttackTurn { get; set; }
        private HealthMechanic Health { get; set; }
        private DamageMechanic Damage { get; set; }
        private DeathMechanic Death { get; set; }
        private HealMechanic Heal { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Initialize

        private RuntimeCharacter()
        {
        }

        public RuntimeCharacter(ICharacterData characterData, IPlayer player)
        {
            SetData(characterData, player);
        }

        public void SetData(ICharacterData data, IPlayer player)
        {
            Owner = player;
            Data = data;
            Attributes = new CharAttributes(Data, Owner);
            Health = new HealthMechanic(this);
            Damage = new DamageMechanic(this);
            Heal = new HealMechanic(this);
            Death = new DeathMechanic(this);
            AttackTurn = new AtkTrnMechanic(this);
        }

        #endregion

        #region Attack

        bool IAttackable.CanAttack()
        {
            return AttackTurn.CanAttack() && !Attributes.HasSummoningSickness;
        }

        void IAttackable.ExecuteAttack()
        {
            AttackTurn.Execute();
        }

        void IAttackable.OnBeforeAttack()
        {
            AttackTurn.OnBeforeAttack();
        }

        void IAttackable.OnAfterAttack()
        {
            AttackTurn.OnAfterAttack();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Damage

        int IDamager.GiveDamage(IDamageable target)
        {
            var dmg = Damage.DoAttack(target);
            return dmg;
        }

        int IDamageable.TakeDamage(IDamager source, int amount)
        {
            var dmg = Health.TakeDamage(source, amount);
            EvaluateDeath();
            return dmg;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Heal

        int IHealer.DoHeal(IHealable target, int healAmount)
        {
            return Heal.DoHeal(target, healAmount);
        }

        int IHealable.TakeHeal(IHealer source, int amount)
        {
            return Health.TakeHeal(source, amount);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
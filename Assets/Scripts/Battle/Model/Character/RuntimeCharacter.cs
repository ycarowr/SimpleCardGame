using Patterns;
using SimpleCardGames.Data.Character;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete character in the game.
    /// </summary>
    public class RuntimeCharacter : IRuntimeCharacter, IPoolable
    {
        //----------------------------------------------------------------------------------------------------------

        public RuntimeCharacter()
        {
        }

        public RuntimeCharacter(ICharacterData characterData, IPlayer player) => SetData(characterData, player);

        //----------------------------------------------------------------------------------------------------------

        public void Restart()
        {
        }

        public ICharacterData Data { get; set; }
        public CharAttributes Attributes { get; private set; }

        //----------------------------------------------------------------------------------------------------------

        #region Death

        public void EvaluateDeath() => Death.EvaluateDeath();

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void IRuntimeCharacter.StartPlayerTurn()
        {
            Attributes.HasSummoningSickness = false;
            AttackTurn.ResetAttackQuantity();
        }

        public void SetData(ICharacterData data, IPlayer player)
        {
            Data = data;
            Attributes = new CharAttributes(Data, player);
            Health = new HealthMechanic(this);
            Damage = new DamageMechanic(this);
            Heal = new HealMechanic(this);
            Death = new DeathMechanic(this);
            AttackTurn = new AttackCharacterMechanic(this);
        }

        //----------------------------------------------------------------------------------------------------------

        #region Mechanics

        AttackCharacterMechanic AttackTurn { get; set; }
        HealthMechanic Health { get; set; }
        DamageMechanic Damage { get; set; }
        DeathMechanic Death { get; set; }
        HealMechanic Heal { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Attack

        bool IAttackable.CanAttack() => AttackTurn.CanAttack() && !Attributes.HasSummoningSickness;

        void IAttackable.ExecuteAttack() => AttackTurn.Execute();

        void IAttackable.OnBeforeAttack() => AttackTurn.OnBeforeAttack();

        void IAttackable.OnAfterAttack() => AttackTurn.OnAfterAttack();

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

        int IHealer.DoHeal(IHealable target, int healAmount) => Heal.DoHeal(target, healAmount);

        int IHealable.TakeHeal(IHealer source, int amount) => Health.TakeHeal(source, amount);

        #endregion
    }
}
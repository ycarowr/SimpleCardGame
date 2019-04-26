using SimpleCardGames.Data.Character;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete character in the game.
    /// </summary>
    public class RuntimeCharacter : ICharacter
    {
        public CharacterData Data { get; private set; }
        public IPlayer Owner { get; private set; }
        public IBoard Board { get; private set; }
        public IBoardPosition Position { get; set; }
        public CharAttributes Attributes { get; private set; }

        //----------------------------------------------------------------------------------------------------------

        #region Mechanics

        private HealthMechanic Health { get; set; }
        private DamageMechanic Damage { get; set; }
        private HealMechanic Heal { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Initialize

        public RuntimeCharacter()
        {
        }

        public RuntimeCharacter(CharacterData characterData, Player player, Board board)
        {
            SetData(characterData, player, board);
        }

        public void SetData(CharacterData cardData, Player player, Board board)
        {
            Owner = player;
            Data = cardData;
            Board = board;
            Attributes = new CharAttributes(Data, Owner);
            Health = new HealthMechanic(this);
            Damage = new DamageMechanic(this);
            Heal = new HealMechanic(this);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Damage

        int IAttackable.DoAttack(IDamageable target, int bonusDamage)
        {
            return Damage.DoAttack(target, bonusDamage);
        }

        int IDamageable.TakeDamage(IAttackable source, int amount)
        {
            return Health.TakeDamage(source, amount);
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
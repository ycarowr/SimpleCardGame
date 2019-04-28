using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete character in the game.
    /// </summary>
    public class RuntimeCharacter : ICharacter
    {
        public ICharacterData Data { get; private set; }
        public IPlayer Owner { get; private set; }
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

        private RuntimeCharacter()
        {
        }

        public RuntimeCharacter(ICharacterData characterData, IPlayer player)
        {
            Debug.Log("Character "+characterData.Name +" Created");
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
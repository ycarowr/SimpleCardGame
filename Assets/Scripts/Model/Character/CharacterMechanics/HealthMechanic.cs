using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class HealthMechanic : CharMechanic
    {
        public HealthMechanic(ICharacter character) : base(character)
        {
        }

        //----------------------------------------------------------------------------------------------------------

        public int TakeDamage(IAttackable source, int amount)
        {
            return IgnoreOverKill(amount);
        }

        private int IgnoreOverKill(int damage)
        {
            var current = Attributes.Health;
            var total = Attributes.Health - damage;
            Attributes.Health = Mathf.Max(total, 0);
            return Attributes.Health - current;
        }

        //----------------------------------------------------------------------------------------------------------

        public int TakeHeal(IHealer source, int amount)
        {
            return IgnoreOverHeal(amount);
        }

        private int IgnoreOverHeal(int heal)
        {
            var current = Attributes.Health;
            var total = Attributes.Health + heal;
            Attributes.Health = Mathf.Min(total, Attributes.DefaultMaxHealth);
            return Attributes.Health - current;
        }
    }
}
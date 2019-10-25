using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class HealthMechanic : CharMechanic
    {
        public HealthMechanic(IRuntimeCharacter character) : base(character)
        {
        }

        //----------------------------------------------------------------------------------------------------------

        public int TakeDamage(IDamager source, int amount) => IgnoreOverKill(amount);

        int IgnoreOverKill(int damage)
        {
            var current = Attributes.Health;
            var total = Attributes.Health - damage;
            Attributes.Health = Mathf.Max(total, 0);
            return Attributes.Health - current;
        }

        //----------------------------------------------------------------------------------------------------------

        public int TakeHeal(IHealer source, int amount) => IgnoreOverHeal(amount);

        int IgnoreOverHeal(int heal)
        {
            var current = Attributes.Health;
            var total = Attributes.Health + heal;
            Attributes.Health = Mathf.Min(total, Attributes.MaxHealth);
            return Attributes.Health - current;
        }
    }
}
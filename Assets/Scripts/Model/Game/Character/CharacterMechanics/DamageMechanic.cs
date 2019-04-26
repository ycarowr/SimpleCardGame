using SimpleCardGames.Data.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class DamageMechanic : CharMechanic
    {
        public DamageMechanic(ICharacter character) : base(character)
        {

        }

        public int DoAttack(IDamageable target, int bonusDamage)
        {
            return target.TakeDamage(Character, bonusDamage);
        }
    }
}

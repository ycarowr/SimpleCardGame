using SimpleCardGames.Data.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class HealMechanic : CharMechanic
    {
        public HealMechanic(ICharacter character) : base(character)
        {

        }

        public int DoHeal(IHealable target, int bonusHeal)
        {
            return target.TakeHeal(Character, bonusHeal);
        }
    }
}

using SimpleCardGames.Battle;
using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Heal")]
    public class HealDataEffect : BaseEffectData, IHealer
    {
        public int DoHeal(IHealable target, int healAmount)
        {
            var dmgHealed = target.TakeHeal(this, healAmount);
            OnDoneHeal(this, target, healAmount);
            return dmgHealed;
        }

        public override void Apply(ITargetable target, IEffectable source) => DoHeal(target as IHealable, Amount);

        void OnDoneHeal(IHealer source, IHealable target, int amount) =>
            GameEvents.Instance.Notify<IDoHeal>(i => i.OnHeal(source, target, amount));
    }
}
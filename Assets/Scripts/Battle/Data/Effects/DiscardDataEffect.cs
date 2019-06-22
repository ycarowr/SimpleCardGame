using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Discard")]
    public class DiscardDataEffect : BaseEffectData
    {
        public override void Apply(ITargetable target, IEffectable source)
        {
            var discardable = target as IDiscardable;
            discardable.DoDiscard(Amount, source);
        }
    }
}
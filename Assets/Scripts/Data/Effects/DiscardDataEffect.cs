using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Discard")]
    public class DiscardDataEffect : BaseEffectData
    {
        public override void Apply(IEffectable target, IEffector source)
        {
            var discardable = target as IDiscardable;
            discardable.DoDiscard(Amount, source);
        }
    }
}
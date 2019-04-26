using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Discard")]
    public class DiscardDataEffect : BaseEffectData
    {
        public override void Apply(IEffectable target, RuntimeCard source)
        {
        }
    }
}
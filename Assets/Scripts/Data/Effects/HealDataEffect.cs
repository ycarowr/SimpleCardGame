using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Heal")]
    public class HealDataEffect : BaseEffectData
    {
        public override void Apply(IEffectable target, RuntimeCard source)
        {
        }
    }
}
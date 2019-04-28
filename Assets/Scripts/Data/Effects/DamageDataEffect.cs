using UnityEngine;

namespace SimpleCardGames.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Damage")]
    public class DamageDataEffect : BaseEffectData
    {
        public override void Apply(IEffectable target, IEffector source)
        {
            Debug.Log("Apply: "+GetType());
        }
    }
}
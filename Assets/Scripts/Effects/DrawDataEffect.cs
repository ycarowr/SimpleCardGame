
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGame.Data.Effects
{
    [CreateAssetMenu(menuName = Path + "/Draw")]
    public class DrawDataEffect : BaseEffectData
    {
        public override void Apply(IEffectable target, RuntimeCard source)
        {
        }
    }
}
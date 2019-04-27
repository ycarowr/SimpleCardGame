using SimpleCardGames.Battle.Controller;
using SimpleCardGames.Data.Effects;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public static class EffectsResolver
    {
        private static IPrimitiveGame GameData => GameController.Instance.Data.RuntimeGame;

        public static void Resolve(BaseEffectData effect, IRuntimeCard source)
        {
            if (effect == null)
            {
                Debug.LogError(source.Data.CardName + " has an empty effect");
                return;
            }

            var targets = effect.Target.GetTargets(source, GameData);
            ResolveEffectOnSet(effect, targets, source);
        }

        private static void ResolveEffectOnSet(BaseEffectData effect, IEffectable[] targetsTileSet, IRuntimeCard source)
        {
            for (var i = 0; i < targetsTileSet.Length; i++)
            {
                var target = targetsTileSet[i];
                effect.Apply(target, source);
            }
        }
    }
}
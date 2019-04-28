using SimpleCardGames.Battle.Controller;
using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public static partial class EffectsDispatcher
    {
        public static class EffectsResolver
        {
            /// <summary>
            ///     Resolves the game data reference using singleton pattern.
            /// </summary>
            private static IPrimitiveGame GameData => GameController.Instance.Data.RuntimeGame;

            /// <summary>
            ///     Resolves and apply an effect caused by a source uppon one or many targets.
            /// </summary>
            /// <param name="effect"></param>
            /// <param name="source"></param>
            public static void Resolve(BaseEffectData effect, IEffector source)
            {
                if (effect == null)
                {
                    Debug.LogError("Can't resolve and null effect.");
                    return;
                }

                //grab all the necessary targets
                var targets = effect.Target.GetTargets(source, GameData);

                //apply the effect on the targets
                ApplyEffect(effect, targets, source);
            }

            private static void ApplyEffect(BaseEffectData effect, IEffectable[] targetsTileSet, IEffector source)
            {
                for (var i = 0; i < targetsTileSet.Length; i++)
                {
                    var target = targetsTileSet[i];
                    effect.Apply(target, source);
                }
            }
        }
    }
}
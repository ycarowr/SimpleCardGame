
using System;
using SimpleCardGames.Data.Effects;
using UnityEngine;
using static SimpleCardGames.Data.Effects.EffectsSet;

namespace SimpleCardGames.Battle
{
    public static partial class EffectsDispatcher
    {
        public static void DispatchEffects(IRuntimeCard card, EffectTriggerType triggerType)
        {
            //grab all effects from the card
            var effects = GetEffects(card);

            //return if the specified trigger is not present
            if (!effects.ContainsKey(triggerType))
                return;

            //grab all effects of the specified trigger
            var effectsByTrigger = effects[triggerType].Effects;

            //dispatch all effects
            foreach (var effect in effectsByTrigger)
                EffectsResolver.Resolve(effect, card);
        }

        private static EffectRegister GetEffects(IRuntimeCard card)
        {
            return card.Data.Effects.Register;
        }
    }
}
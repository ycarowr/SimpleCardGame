
using System;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    public class EffectsDispatcher
    {
        private static void DispatchEvents(IRuntimeCard card, EffectTriggerType triggerType)
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

        private static EffectsByTrigger GetEffects(IRuntimeCard card)
        {
            return card.Data.Effects.EffectsByTrigger;
        }
    }
}
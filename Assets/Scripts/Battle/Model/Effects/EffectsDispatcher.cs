using System.Linq;
using SimpleCardGames.Data.Effects;
using static SimpleCardGames.Data.Effects.EffectsSet;

namespace SimpleCardGames.Battle
{
    public static partial class EffectsDispatcher
    {
        //TODO: Merge these two classes into one. I'm building out the relic class now, so don't want too fuck up two things at once
        public static void DispatchEffects(IRuntimeCard card, EffectTriggerType triggerType)
        {
            //grab all effects from the card
            var effects = GetEffects(card);

            //return if the specified trigger is not present
            if (effects.All(eff => eff.Key.tType != triggerType))
                return;

            //grab all effects of the specified trigger
            var effectsByTrigger = effects[effects.First(eff => eff.Key.tType == triggerType).Key].Effects;

            //dispatch all effects
            foreach (var effect in effectsByTrigger)
                EffectsResolver.Resolve(effect, card, card.Targets[effect]);
        }

        static EffectRegister GetEffects(IRuntimeCard card) => card.Data.Effects.Register;
    }
}
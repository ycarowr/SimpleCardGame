using SimpleCardGames.Data;
using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A card at the runtime.
    /// </summary>
    public class RuntimeCard : IRuntimeCard
    {
        public RuntimeCard(ICardData data)
        {
            SetData(data);
        }

        EffectsSet IEffector.Effects => Data.Effects;

        /// <summary>
        ///     Reference for all card data.
        /// </summary>
        public ICardData Data { get; private set; }

        /// <summary>
        ///     Set the data inside a card.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICardData data)
        {
            Data = data;
        }

        /// <summary>
        ///     Called when it is drawn.
        /// </summary>
        public void Draw()
        {
            EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnDraw);
        }

        /// <summary>
        ///     Called when it is played.
        /// </summary>
        public void Play()
        {
            EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnPlay);
        }

        /// <summary>
        ///     Called when it is discarded.
        /// </summary>
        public void Discard()
        {
            EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnDiscard);
        }
    }
}
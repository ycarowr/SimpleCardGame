using System.Collections.Generic;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Effects;

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

        public Dictionary<BaseEffectData, ITargetable[]> Targets { get; private set; }

        public void AddTargets(BaseEffectData effect, ITargetable[] targets)
        {
            Targets.Add(effect, targets);
        }

        EffectsSet IEffectable.Effects => Data.Effects;

        /// <summary>
        ///     Reference for all card data.
        /// </summary>
        public ICardData Data { get; private set; }

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

        /// <summary>
        ///     Reset all values.
        /// </summary>
        public void Reset()
        {
            Targets.Clear();
        }

        public void SetTargets(Dictionary<BaseEffectData, ITargetable[]> target)
        {
            Targets = target;
        }

        /// <summary>
        ///     Set the data inside a card.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICardData data)
        {
            Targets = new Dictionary<BaseEffectData, ITargetable[]>();
            Data = data;
        }
    }
}
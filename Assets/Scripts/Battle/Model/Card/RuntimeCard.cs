using System.Collections.Generic;
using Patterns;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A card at the runtime.
    /// </summary>
    public class RuntimeCard : IRuntimeCard, IPoolable
    {
        public RuntimeCard() => Restart();

        public RuntimeCard(ICardData data)
        {
            Restart();
            SetData(data);
        }

        public Dictionary<BaseEffectData, ITargetable[]> Targets { get; private set; } =
            new Dictionary<BaseEffectData, ITargetable[]>();

        EffectsSet IEffectable.Effects => Data.Effects;

        /// <summary>
        ///     Reference for all card data.
        /// </summary>
        public ICardData Data { get; private set; }

        public void AddTargets(BaseEffectData effect, ITargetable[] targets) => Targets.Add(effect, targets);

        /// <summary>
        ///     Called when it is drawn.
        /// </summary>
        public void Draw() => EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnDraw);

        /// <summary>
        ///     Called when it is played.
        /// </summary>
        public void Play() => EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnPlay);

        /// <summary>
        ///     Called when it is discarded.
        /// </summary>
        public void Discard() => EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnDiscard);

        /// <summary>
        ///     Reset all values.
        /// </summary>
        public void Restart() => Targets.Clear();

        public void SetTargets(Dictionary<BaseEffectData, ITargetable[]> target) => Targets = target;

        /// <summary>
        ///     Set the data inside a card.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICardData data) => Data = data;
    }
}
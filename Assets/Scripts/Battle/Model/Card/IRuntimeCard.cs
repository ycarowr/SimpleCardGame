using System.Collections.Generic;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames
{
    public interface IRuntimeCard : IEffectable
    {
        Dictionary<BaseEffectData, ITargetable[]> Targets { get; }
        ICardData Data { get; }
        void Play();
        void Discard();
        void Draw();
        void AddTargets(BaseEffectData effect, ITargetable[] targets);
        void Reset();
    }
}
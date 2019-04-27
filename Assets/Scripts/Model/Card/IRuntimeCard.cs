using SimpleCardGames.Data;
using SimpleCardGames.Data.Effects;

namespace SimpleCardGames
{
    public interface IRuntimeCard : IEffector
    {
        ICardData Data { get; }
        void Play();
        void Discard();
        void Draw();
    }
}
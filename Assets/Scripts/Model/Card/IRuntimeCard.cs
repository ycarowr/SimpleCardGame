using SimpleCardGames.Data;

namespace SimpleCardGames
{
    public interface IRuntimeCard
    {
        ICardData Data { get; }
        void Play();
    }
}
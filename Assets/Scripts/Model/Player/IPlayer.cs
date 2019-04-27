using SimpleCardGames.Data.Effects;
using Tools;

namespace SimpleCardGames.Battle
{
    public interface IPlayer : IEffectable
    {
        Configurations Configurations { get; }
        Collection<IRuntimeCard> Hand { get; }
        PlayerSeat Seat { get; }
        ITeam Team { get; }
        void StartTurn();
        void FinishTurn();
        void DrawStartingHand();
        bool Draw();
        bool Play(IRuntimeCard card);
        bool Discard(IRuntimeCard card);
    }
}
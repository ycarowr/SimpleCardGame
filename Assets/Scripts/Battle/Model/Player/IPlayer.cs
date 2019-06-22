using SimpleCardGames.Data.Effects;
using Tools;

namespace SimpleCardGames.Battle
{
    public interface IPlayer : ITargetable, IDrawable, IDiscardable, ISpawner, IManaManipulator
    {
        Configurations Configurations { get; }
        Collection<IRuntimeCard> Hand { get; }
        ILibrary Library { get; }
        Graveyard Graveyard { get; }
        PlayerSeat Seat { get; }
        ITeam Team { get; }
        int Mana { get; }
        void StartTurn();
        void FinishTurn();
        void DrawStartingHand();
        bool Draw();
        bool Play(IRuntimeCard card);
        bool CanPlay(IRuntimeCard card);
        bool Discard(IRuntimeCard card);
    }
}
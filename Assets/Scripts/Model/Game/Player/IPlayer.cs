namespace SimpleCardGames.Battle
{
    public interface IPlayer
    {
        Configurations Configurations { get; }
        PlayerSeat Seat { get; }
        void StartTurn();
        void FinishTurn();
    }
}
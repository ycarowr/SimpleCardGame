namespace SimpleCardGames.Battle
{
    public interface IPlayerTurn
    {
        bool IsAi { get; }
        bool IsUser { get; }
        bool IsMyTurn { get; }
        PlayerSeat Seat { get; }
        IPlayer Player { get; }
        bool PlayCard(IRuntimeCard card);
    }
}
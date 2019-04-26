namespace SimpleTurnBasedGame
{
    public interface IUiPlayer : IUiController, IUiPlayerController
    {
        PlayerSeat Seat { get; }
    }
}
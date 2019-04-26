namespace SimpleCardGames.Battle
{
    public interface IUiPlayer : IUiController, IUiPlayerController
    {
        PlayerSeat Seat { get; }
    }
}
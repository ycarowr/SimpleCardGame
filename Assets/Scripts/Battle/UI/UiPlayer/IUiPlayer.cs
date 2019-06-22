namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A player interface which has as references to controllers.
    /// </summary>
    public interface IUiPlayer : IUiController, IUiPlayerController
    {
        PlayerSeat Seat { get; }
    }
}
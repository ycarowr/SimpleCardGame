namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     An interface that provides reference to a player controller.
    /// </summary>
    public interface IUiPlayerController
    {
        IPlayerTurn PlayerController { get; }
    }
}
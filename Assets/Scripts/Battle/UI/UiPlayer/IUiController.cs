namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     An interface that provides reference to the main game controller.
    /// </summary>
    public interface IUiController
    {
        IGameController Controller { get; }
    }
}
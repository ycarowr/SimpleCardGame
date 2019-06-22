namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Small Part of a Turn.
    /// </summary>
    public abstract class BaseGameMechanics
    {
        protected BaseGameMechanics(IGame game)
        {
            Game = game;
        }

        /// <summary>
        ///     All game data.
        /// </summary>
        protected IGame Game { get; set; }
    }
}
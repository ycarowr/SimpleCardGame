namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Small Part of a Turn.
    /// </summary>
    public abstract class BaseGameMechanics
    {
        protected BaseGameMechanics(IPrimitiveGame game)
        {
            Game = game;
        }

        /// <summary>
        ///     All game data.
        /// </summary>
        protected IPrimitiveGame Game { get; set; }
    }
}
namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Base class for any complex player mechanic.
    /// </summary>
    public abstract class BasePlayerMechanics
    {
        /// <summary>
        ///     Player reference.
        /// </summary>
        protected IPlayer Player { get; }


        protected BasePlayerMechanics(IPlayer player)
        {
            Player = player;
        }
    }
}
namespace SimpleCardGames.Battle
{
    /// <inheritdoc />
    /// <summary>
    ///     Finish Game Step Implementation.
    /// </summary>
    public class ProcessFinishGame : ProcessBase
    {
        public ProcessFinishGame(IPrimitiveGame game) : base(game)
        {
        }

        public void Execute(IPlayer winner)
        {
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsGameFinished = true;

            OnGameFinished(winner);
        }

        /// <summary>
        ///     Dispatch end game to the listeners.
        /// </summary>
        /// <param name="winner"></param>
        private void OnGameFinished(IPlayer winner)
        {
            GameEvents.Instance.Notify<IFinishGame>(i => i.OnFinishGame(winner));
        }
    }
}
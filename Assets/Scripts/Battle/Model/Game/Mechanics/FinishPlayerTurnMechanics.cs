namespace SimpleCardGames.Battle
{
    /// <inheritdoc />
    /// <summary>
    ///     Finish Current player Turn Implementation.
    /// </summary>
    public class FinishPlayerTurnMechanics : BaseGameMechanics
    {
        public FinishPlayerTurnMechanics(IPrimitiveGame game) : base(game)
        {
        }


        /// <summary>
        ///     Finish player turn logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.TurnLogic.CurrentPlayer.FinishTurn();
            Game.TurnTime = 0;
            OnFinishedCurrentPlayerTurn(Game.TurnLogic.CurrentPlayer);
        }

        /// <summary>
        ///     Dispatch to the listeners.
        /// </summary>
        /// <param name="currentPlayer"></param>
        private void OnFinishedCurrentPlayerTurn(IPlayer currentPlayer)
        {
            GameEvents.Instance.Notify<IFinishPlayerTurn>(i => i.OnFinishPlayerTurn(currentPlayer));
        }
    }
}
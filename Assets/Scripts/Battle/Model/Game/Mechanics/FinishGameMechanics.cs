namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Finish Game Step Implementation.
    /// </summary>
    public class FinishGameMechanics : BaseGameMechanics
    {
        public FinishGameMechanics(IGame game) : base(game)
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

        public void CheckWinCondition()
        {
            var playerLeft = Game.TurnLogic.GetPlayer(PlayerSeat.Left);
            var playerRight = Game.TurnLogic.GetPlayer(PlayerSeat.Right);

            var captainLeft = playerLeft.Team.Captain?.Attributes?.IsDead;
            var captainRight = playerRight.Team.Captain?.Attributes?.IsDead;

            //player has privilege when TIE
            if (playerRight.Team.IsEmpty || captainRight.HasValue && captainRight.Value)
                OnGameFinished(playerLeft);
            else if (playerLeft.Team.IsEmpty || captainLeft.HasValue && captainLeft.Value)
                OnGameFinished(playerRight);
        }


        /// <summary>
        ///     Dispatch end game to the listeners.
        /// </summary>
        /// <param name="winner"></param>
        void OnGameFinished(IPlayer winner)
        {
            var playerLeft = Game.TurnLogic.GetPlayer(PlayerSeat.Left);
            GameEvents.Instance.Notify<IFinishGame>(i => i.OnFinishGame(winner));
        }
    }
}
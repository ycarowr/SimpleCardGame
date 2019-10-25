namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Tick time Logic Implementation
    /// </summary>
    public class TickTimeMechanics : BaseGameMechanics
    {
        public TickTimeMechanics(IGame game) : base(game)
        {
        }

        float TimeOutTurn => Game.Configurations.TimeOutTurn;
        float TimeStartTurn => Game.Configurations.TimeStartTurn;

        /// <summary>
        ///     Execution of the tick logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress)
                return;

            if (!Game.IsGameStarted)
                return;

            if (Game.IsGameFinished)
                return;

            //Game.TurnTime++;
            //Game.TotalTime++;
            //var reverseTime = (int) (TimeOutTurn - 1 - Game.TurnTime - TimeStartTurn);
            //OnTickTime(reverseTime, Game.TurnLogic.CurrentPlayer);
        }

        /// <summary>
        ///     Dispatch tick time to the listeners.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="current"></param>
        void OnTickTime(int time, IPlayer current) =>
            GameEvents.Instance.Notify<IDoTick>(i => i.OnTickTime(time, current));
    }
}
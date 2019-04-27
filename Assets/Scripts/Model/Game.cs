using System.Collections.Generic;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Simple concrete Game Implementation.
    ///     TODO: Consider to break this class down into small partial classes.
    /// </summary>
    public class Game : IPrimitiveGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public Game(List<IPlayer> players, Configurations configurations)
        {
            Configurations = configurations;
            ProcessTurn = new ProcessTurn(players);
            ProcessPreStartGame = new ProcessPreStartGame(this);
            ProcessStartGame = new ProcessStartGame(this);
            ProcessStartPlayerTurn = new ProcessStartPlayer(this);
            ProcessFinishPlayerTurn = new ProcessFinishPlayer(this);
            ProcessTick = new ProcessTick(this);
            Logger.Instance.Log<Game>("Game Created", "blue");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public List<IPlayer> Players => ProcessTurn.Players;
        public ITurnLogic TurnLogic => ProcessTurn;
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public bool IsTurnInProgress { get; set; }
        public int TurnTime { get; set; }
        public int TotalTime { get; set; }
        public Configurations Configurations { get; }

        #region Processes

        private ProcessTurn ProcessTurn { get; }
        private ProcessPreStartGame ProcessPreStartGame { get; }
        private ProcessStartGame ProcessStartGame { get; }
        private ProcessTick ProcessTick { get; }
        private ProcessStartPlayer ProcessStartPlayerTurn { get; }
        private ProcessFinishPlayer ProcessFinishPlayerTurn { get; }

        #endregion

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Execution

        public void PreStartGame()
        {
            ProcessPreStartGame.Execute();
        }

        public void StartGame()
        {
            ProcessStartGame.Execute();
        }

        public void StartCurrentPlayerTurn()
        {
            ProcessStartPlayerTurn.Execute();
        }

        public void FinishCurrentPlayerTurn()
        {
            ProcessFinishPlayerTurn.Execute();
        }

        public void Tick()
        {
            ProcessTick.Execute();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
using System.Collections.Generic;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Simple concrete Game Implementation.
    ///     TODO: Consider to break this class down into small partial classes.
    /// </summary>
    public class Game : IGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public Game(List<IPlayer> players, Configurations configurations)
        {
            Configurations = configurations;
            ProcessTurn = new ProcessTurn(players);
            ProcessPreStartGame = new PreStartGameMechanics(this);
            ProcessStartGame = new StartGameMechanics(this);
            ProcessStartPlayerTurn = new StartPlayerTurnMechanics(this);
            ProcessFinishPlayerTurn = new FinishPlayerTurnMechanics(this);
            ProcessTick = new TickTimeMechanics(this);
            ProcessAttack = new AttackMechanics(this);
            ProcessFinishGame = new FinishGameMechanics(this);

            AddMechanic(ProcessPreStartGame);
            AddMechanic(ProcessStartGame);
            AddMechanic(ProcessStartPlayerTurn);
            AddMechanic(ProcessFinishPlayerTurn);
            AddMechanic(ProcessTick);
            AddMechanic(ProcessAttack);
            AddMechanic(ProcessFinishGame);
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

        public List<BaseGameMechanics> Mechanics { get; set; } = new List<BaseGameMechanics>();
        private ProcessTurn ProcessTurn { get; }
        private PreStartGameMechanics ProcessPreStartGame { get; }
        private StartGameMechanics ProcessStartGame { get; }
        private TickTimeMechanics ProcessTick { get; }
        private StartPlayerTurnMechanics ProcessStartPlayerTurn { get; }
        private FinishPlayerTurnMechanics ProcessFinishPlayerTurn { get; }
        private AttackMechanics ProcessAttack { get; }
        private FinishGameMechanics ProcessFinishGame { get; }

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

        public void Attack(AttackMechanics.RuntimeAttackData data)
        {
            ProcessAttack.Execute(data);
        }

        private void AddMechanic(BaseGameMechanics mechanic)
        {
            Mechanics.Add(mechanic);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
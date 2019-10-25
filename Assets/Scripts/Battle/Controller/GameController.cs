using Patterns;
using UnityEngine;

namespace SimpleCardGames.Battle.Controller
{
    /// <summary>
    ///     Main Controller. Holds the FSM which controls the game flow. Also provides access to the players controllers.
    /// </summary>
    public class GameController : SingletonMB<GameController>, IGameController
    {
        [SerializeField] Configurations configurations;

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        ///     All game data. Access via Singleton Pattern.
        /// </summary>
        public IGameData Data => GameData.Instance;

        /// <summary>
        ///     State machine that holds the game logic.
        /// </summary>
        TurnBasedFsm TurnBasedLogic { get; set; }

        /// <summary>
        ///     Handler for the state machine. Used to dispatch coroutines.
        /// </summary>
        public MonoBehaviour MonoBehaviour => this;

        public string Name => gameObject.name;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Initialization

        protected override void OnAwake() => Debug.Log("Awake");

        void Start()
        {
            Debug.Log("Start");

            StartBattle();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Return the Left Player. TODO: Define this value inside the configurations.
        /// </summary>
        /// <returns></returns>
        public IPlayerTurn GetUser() => GetPlayerController(PlayerSeat.Left);

        /// <summary>
        ///     Provides access to players controllers according to the player seat.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public IPlayerTurn GetPlayerController(PlayerSeat seat) => TurnBasedLogic.GetPlayerController(seat);

        /// <summary>
        ///     Start the battle. Called only once after being initialized by the Bootstrapper.
        /// </summary>
        [Button]
        public void StartBattle()
        {
            TurnBasedLogic = new TurnBasedFsm(this, Data, configurations);
            TurnBasedLogic.StartBattle();
        }

        [Button]
        public void EndBattle() => TurnBasedLogic.EndBattle();

        [Button]
        public void RestartGameImmediately()
        {
            GameEvents.Instance.Notify<IRestartGame>(i => i.OnRestart());
            Data.CreateGame();
            StartBattle();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame.ControllerMB
{
    /// <summary>
    ///     GameControllerMB works as GameController and holds all the Logic
    /// </summary>
    //Game Data
    [RequireComponent(typeof(IGameData))]
    [RequireComponent(typeof(TopPlayerState))]
    [RequireComponent(typeof(BottomPlayerState))]
    [RequireComponent(typeof(StartBattleState))]
    [RequireComponent(typeof(EndBattleState))]
    public class GameControllerMB : StateMachineMB<GameControllerMB>
    {
        //Register with all States of the Players that are in the Match. Each state controls
        //the flow of the game 
        private readonly Dictionary<IPrimitivePlayer, TurnState> actorsRegister =
            new Dictionary<IPrimitivePlayer, TurnState>();

        public IGameData GameData { get; private set; }

        /// <summary>
        ///     Register the dependencies to its respective turn state.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="state"></param>
        public void RegisterPlayerState(IPrimitivePlayer player, TurnState state)
        {
            actorsRegister.Add(player, state);
        }

        /// <summary>
        ///     Returns whether the current player is sitting on a specified seat.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public bool IsMyTurn(PlayerSeat seat)
        {
            if (!IsInitialized)
                return false;

            var currentState = PeekState();
            return currentState != null && GetPlayer(seat).IsMyTurn();
        }

        /// <summary>
        ///     Returns a Turn according to its registered player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public TurnState GetPlayer(IPrimitivePlayer player)
        {
            return IsInitialized && actorsRegister.ContainsKey(player) ? actorsRegister[player] : null;
        }

        /// <summary>
        ///     Returns a the player turn according to the position. Null if there isn't player registered with the argument.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public TurnState GetPlayer(PlayerSeat seat)
        {
            foreach (var player in actorsRegister.Keys)
                if (player.Seat == seat)
                    return actorsRegister[player];

            return null;
        }

        /// <summary>
        ///     Call this method to Push Start Battle State and begin the match.
        /// </summary>
        public void StartBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState<StartBattleState>();
        }

        /// <summary>
        ///     Call this method to Push End Battle State and Finish the match.
        /// </summary>
        public void EndBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState<EndBattleState>();
        }

        /// <summary>
        ///     Deletes current game data and restarts the state machine with a new game data.
        /// </summary>
        [Button("Clear Immediately")]
        public void RestartGameImmediately()
        {
            //restart fsm 
            Restart();

            //overrides game data
            GameData.Clear();
            GameData.CreateGame();

            //reinitialize the fsm
            Initialize();

            StartBattle();
        }

        /// <summary>
        ///     Checks whether the current state is Bottom or not.
        /// </summary>
        /// <returns></returns>
        public bool IsUser()
        {
            if (!IsInitialized)
                return false;

            var currentState = PeekState();
            return currentState is BottomPlayerState;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Initializes the state machine after game data is ready. And kicks the start battle.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            StartBattle();
        }

        protected override void OnBeforeInitialize()
        {
            GameData = GetComponent<IGameData>();
        }

        public override void Restart()
        {
            base.Restart();

            //reset states
            foreach (var turnState in actorsRegister.Values)
                turnState.Restart();

            //clear turn state register
            actorsRegister.Clear();
        }
    }
}
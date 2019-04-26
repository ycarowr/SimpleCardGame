using Patterns.StateMachine;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public interface IGameController : IStateMachineHandler, IGameDataHandler
    {
        MonoBehaviour MonoBehaviour { get; }
        IPlayerTurn GetPlayerController(PlayerSeat seat);
        void StartBattle();
        void EndBattle();
        void RestartGameImmediately();
    }
}
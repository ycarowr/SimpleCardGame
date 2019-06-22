using System.Collections.Generic;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A game interface.
    /// </summary>
    public interface IGame
    {
        Configurations Configurations { get; }

        List<BaseGameMechanics> Mechanics { get; }

        List<IPlayer> Players { get; }

        ITurnLogic TurnLogic { get; }

        bool IsGameStarted { get; set; }

        bool IsGameFinished { get; set; }

        bool IsTurnInProgress { get; set; }

        int TurnTime { get; set; }

        int TotalTime { get; set; }

        void PreStartGame();

        void StartGame();

        void StartCurrentPlayerTurn();

        void FinishCurrentPlayerTurn();

        void Tick();

        void Attack(AttackMechanics.RuntimeAttackData data);
    }
}
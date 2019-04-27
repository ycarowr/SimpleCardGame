using System.Collections.Generic;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <inheritdoc />
    /// <summary>
    ///     Pre Start Game Step Implementation.
    /// </summary>
    public class ProcessPreStartGame : ProcessBase
    {
        public ProcessPreStartGame(IPrimitiveGame game) : base(game)
        {
        }

        /// <summary>
        ///     Execution of start game
        /// </summary>
        public void Execute()
        {
            if (Game.IsGameStarted) return;

            //players draw starting cards
            DrawStartingHands();

            OnGamePreStarted(Game.TurnLogic.Players);
        }


        private void DrawStartingHands()
        {
            foreach (var player in Game.Players)
                player.DrawStartingHand();
        }

        /// <summary>
        ///     Dispatch pre start game event to the listeners
        /// </summary>
        /// <param name="players"></param>
        private void OnGamePreStarted(List<IPlayer> players)
        {
            GameEvents.Instance.Notify<IPreGameStart>(i => i.OnPreGameStart(players));
        }
    }
}
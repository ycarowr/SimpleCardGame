using System.Collections.Generic;

namespace SimpleCardGames.Battle
{
    /// <inheritdoc />
    /// <summary>
    ///     Pre Start Game Step Implementation.
    /// </summary>
    public class PreStartGameMechanics : BaseGameMechanics
    {
        public PreStartGameMechanics(IGame game) : base(game)
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


        void DrawStartingHands()
        {
            if (!Game.Configurations.WithStartingHands)
                return;

            foreach (var player in Game.Players)
                player.DrawStartingHand();
        }

        /// <summary>
        ///     Dispatch pre start game event to the listeners
        /// </summary>
        /// <param name="players"></param>
        void OnGamePreStarted(List<IPlayer> players) =>
            GameEvents.Instance.Notify<IPreGameStart>(i => i.OnPreGameStart(players));
    }
}
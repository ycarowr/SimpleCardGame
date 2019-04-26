using System;
using System.Linq;
using Extensions;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Base for all the Artificial Intelligence of the game.
    /// </summary>
    public abstract class AiBase
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected AiBase(IPlayer player, IPrimitiveGame game)
        {
            Game = game;
            Player = player;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        protected IPrimitiveGame Game { get; }
        protected IPlayer Player { get; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        public abstract MoveType GetBestMove();

        protected MoveType[] GetAllMoves()
        {
            return Enum.GetValues(typeof(MoveType)).Cast<MoveType>().ToArray();
        }

        protected MoveType GetRandomExcept(MoveType move)
        {
            var allMoves = GetAllMoves().ToList();
            allMoves.Remove(move);
            return allMoves.RandomItem();
        }

        protected bool IsFullHealth()
        {
            return false;
            //return Player.IsFullHealth;
        }

        protected bool CanKill()
        {
            var enemy = Game.TurnLogic.GetOpponent(Player);
            return false;
            //return enemy.Health == 1;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
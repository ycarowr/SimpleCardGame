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
            Enemy = game.TurnLogic.GetOpponent(player);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        public abstract AttackMechanics.RuntimeAttackData[] GetAttackMoves();

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        protected IPrimitiveGame Game { get; }
        protected IPlayer Player { get; }
        protected IPlayer Enemy { get; }

        #endregion


        //----------------------------------------------------------------------------------------------------------
    }
}
namespace SimpleCardGames.Battle.Controller
{
    /// <summary>
    ///     Holds the Game flow when a match is Finished.
    /// </summary>
    public class EndBattleState : BaseBattleState, IFinishGame
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public EndBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPlayer winner) => Fsm.EndBattle();

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
namespace SimpleCardGames.Battle.Controller
{
    public class TopPlayerState : AiTurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public TopPlayerState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public override PlayerSeat Seat => PlayerSeat.Right;
        public override bool IsAi => Configurations.TopIsAi;
        protected override AiArchetype AiArchetype => Configurations.TopAiArchetype;
        public override bool IsUser => false;

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
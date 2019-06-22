namespace SimpleCardGames.Battle.Controller
{
    /// <summary>
    ///     It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    public class UiUserTeamController : UiPlayerTeamController
    {
        public override PlayerSeat Seat => PlayerSeat.Left;
    }
}
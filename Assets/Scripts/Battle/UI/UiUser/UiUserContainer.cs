namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     User HUD
    /// </summary>
    public class UiUserContainer : UiPlayer
    {
        public override PlayerSeat Seat => PlayerSeat.Left;

        void Awake()
        {
            //HUD input
            gameObject.AddComponent<UiUserInput>();

            //Ui elements for pre start game
            gameObject.AddComponent<UiPreStartGameUser>();

            //Ui elements for start user turn
            gameObject.AddComponent<UiStartUserTurn>();

            //Ui elements for finish user turn
            gameObject.AddComponent<UiFinishUserTurn>();

            //HUD buttons
            gameObject.AddComponent<UiUserHudButtons>();
        }
    }
}
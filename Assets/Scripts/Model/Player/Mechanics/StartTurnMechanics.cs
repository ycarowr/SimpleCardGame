namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Start turn player mechanics.
    /// </summary>
    public class StartTurnMechanics : BasePlayerMechanics
    {
        public StartTurnMechanics(IPlayer player) : base(player)
        {

        }

        public void StartTurn()
        {
            var quant = Player.Configurations.Amount.LibraryPlayer.drawAmountByTurn;
            for (int i = 0; i < quant; i++)
                Player.Draw();
        }
    }
}
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

            //draw cards
            for (var i = 0; i < quant; i++)
                Player.Draw();

            //start turn for all members
            foreach (var mem in Player.Team.Members)
                mem.StartPlayerTurn();

            //replanish mana
            Player.ReplanishMana();
        }
    }
}
namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Finish turn player mechanics.
    /// </summary>
    public class FinishTurnMechanics : BasePlayerMechanics
    {
        public FinishTurnMechanics(IPlayer player) : base(player)
        {
        }

        public void FinishTurn()
        {
            var isDiscard = Player.Configurations.Amount.LibraryPlayer.isDiscardableHands;
            if (isDiscard)
                DiscardAll();
        }

        private void DiscardAll()
        {
            var quant = Player.Hand.Size;
            for (var i = 0; i < quant; i++)
                Player.Discard(Player.Hand.Units[0]);
        }
    }
}
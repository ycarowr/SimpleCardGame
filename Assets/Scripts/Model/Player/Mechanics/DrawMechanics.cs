namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Draw card mechanics.
    /// </summary>
    public class DrawMechanics : BasePlayerMechanics
    {
        public DrawMechanics(IPlayer player) : base(player)
        {

        }

        public bool Draw()
        {
            if (Player.Library == null)
                return false;

            var card = Player.Library.DrawTop();
            card.Draw();
            Player.Hand.Add(card);
            OnDrawCard(Player, card);
            return true;
        }

        public void DrawStartingHand()
        {
            var quant = Player.Configurations.Amount.LibraryPlayer.startingAmount;
            for (int i = 0; i < quant; i++)
                Draw();
        }

        public void DoDraw(int amount, Data.Effects.IEffector source)
        {
            for (var i = 0; i < amount; i++)
                Draw();
        }

        /// <summary>
        ///     Dispatch card draw to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void OnDrawCard(IPlayer player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<IPlayerDrawCard>(i => i.OnDrawCard(player, card));
        }
    }
}
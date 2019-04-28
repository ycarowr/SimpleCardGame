using Extensions;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Discard cards player mechanics.
    /// </summary>
    public class DiscardMechanics : BasePlayerMechanics
    {
        public DiscardMechanics(IPlayer player) : base(player)
        {

        }

        public void DoDiscard(int amount, Data.Effects.IEffector source)
        {
            for (var i = 0; i < amount; i++)
            {
                if (Player.Hand.Size <= 0)
                    break;

                var card = Player.Hand.Units.RandomItem();
                Discard(card);
            }
        }

        public bool Discard(IRuntimeCard card)
        {
            var hasCard = Player.Hand.Has(card);
            if (!hasCard)
                return false;
            card.Discard();
            Player.Hand.Remove(card);
            OnDiscardCard(Player, card);
            return true;
        }

        /// <summary>
        ///     Dispatch card discarded to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void OnDiscardCard(IPlayer player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<IPlayerDiscardCard>(i => i.OnDiscardCard(player, card));
        }
    }
}
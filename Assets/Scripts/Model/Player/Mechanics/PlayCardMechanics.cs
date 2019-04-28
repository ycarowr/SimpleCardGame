using Extensions;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Play cards player mechanics.
    /// </summary>
    public class PlayCardMechanics : BasePlayerMechanics
    {
        public PlayCardMechanics(IPlayer player) : base(player)
        {

        }

        public bool Play(IRuntimeCard card)
        {
            var hasCard = Player.Hand.Has(card);
            if (!hasCard)
                return false;

            Player.Hand.Remove(card);
            card.Play();
            OnPlayCard(Player, card);
            return true;
        }

        /// <summary>
        ///     Dispatch card played to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void OnPlayCard(IPlayer player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<IPlayerPlayCard>(i => i.OnPlayCard(player, card));
        }
    }
}
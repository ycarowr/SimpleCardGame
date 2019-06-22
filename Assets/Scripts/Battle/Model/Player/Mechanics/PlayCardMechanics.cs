using SimpleCardGames.Data.Card;

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


        public bool CanPlay(IRuntimeCard card)
        {
            var cost = card.Data.CardCost;
            var hasMana = Player.HasMana(cost);
            return hasMana;
        }

        public bool Play(IRuntimeCard card)
        {
            var hasCard = Player.Hand.Has(card);
            if (!hasCard)
                return false;

            var cost = card.Data.CardCost;
            Player.ConsumeMana(cost);
            Player.Hand.Remove(card);
            card.Play();
            Player.Graveyard.AddCard(card);
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
            switch (card.Data.CardType)
            {
                case CardType.Minion:
                    GameEvents.Instance.Notify<IPlayerPlayMinionCard>(i => i.OnPlayMinionCard(player, card));
                    break;
                case CardType.Power:
                    GameEvents.Instance.Notify<IPlayerPlayPowerCard>(i => i.OnPlayPowerCard(player, card));
                    break;
                case CardType.Spell:
                    GameEvents.Instance.Notify<IPlayerPlaySpellCard>(i => i.OnPlaySpellCard(player, card));
                    break;
                case CardType.Curse:
                    GameEvents.Instance.Notify<IPlayerPlayCurseCard>(i => i.OnPlayCurseCard(player, card));
                    break;
            }
        }
    }
}
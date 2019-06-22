using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Effects;

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
            if (card == null)
                return false;

            card.Draw();
            Player.Hand.Add(card);
            OnDrawCard(Player, card);
            return true;
        }

        public void DrawStartingHand()
        {
            var quant = Player.Configurations.Amount.LibraryPlayer.startingAmount;
            for (var i = 0; i < quant; i++)
                Draw();
        }

        public void DoDraw(int amount, IEffectable source)
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
            switch (card.Data.CardType)
            {
                case CardType.Minion:
                    GameEvents.Instance.Notify<IPlayerDrawMinionCard>(i => i.OnDrawMinionCard(player, card));
                    break;
                case CardType.Power:
                    GameEvents.Instance.Notify<IPlayerDrawPowerCard>(i => i.OnDrawPowerCard(player, card));
                    break;
                case CardType.Spell:
                    GameEvents.Instance.Notify<IPlayerDrawSpellCard>(i => i.OnDrawSpellCard(player, card));
                    break;
                case CardType.Curse:
                    GameEvents.Instance.Notify<IPlayerDrawCurseCard>(i => i.OnDrawCurseCard(player, card));
                    break;
            }
        }
    }
}
namespace SimpleCardGames.Battle.UI.Card
{
    public class UiCardDrawListener : UiListener, IPlayerDrawCard
    {
        private UiPlayerHandUtils CardUtils { get; set; }
        private IUiPlayer UiPlayer { get; set; }

        void IPlayerDrawCard.OnDrawCard(IPlayer player, IRuntimeCard card)
        {
            if (player.Seat != UiPlayer.Seat)
                return;

            CardUtils.Draw(card);
        }

        private void Awake()
        {
            CardUtils = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            UiPlayer = transform.parent.GetComponentInChildren<IUiPlayer>();
        }
    }
}
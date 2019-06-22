using Extensions;
using SimpleCardGames.Battle.Controller;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    public class UiCardDiscardListener : UiListener, IPlayerDiscardCard
    {
        private UiPlayerHandUtils CardUtils { get; set; }
        private IUiPlayer UiPlayer { get; set; }

        void IPlayerDiscardCard.OnDiscardCard(IPlayer player, IRuntimeCard card)
        {
            if (player.Seat != UiPlayer.Seat)
                return;

            CardUtils.Discard(card);
        }

        private void Awake()
        {
            CardUtils = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            UiPlayer = transform.parent.GetComponentInChildren<IUiPlayer>();
        }


        // TOOD: it will be removed
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var myPlayer = GameController.Instance.GetPlayerController(PlayerSeat.Left).Player;
                if (myPlayer.Hand.Size > 0)
                {
                    var rndCard = myPlayer.Hand.Units.RandomItem();
                    if (rndCard != null)
                        myPlayer.Discard(rndCard);
                }
            }
        }
    }
}
using System.Collections.Generic;
using Extensions;
using Patterns;
using SimpleCardGames;
using SimpleCardGames.Battle;
using SimpleCardGames.Battle.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    public class UiCardDiscardListener : UiListener, IPlayerDiscardCard
    {
        private UiCardUtils CardUtils { get; set; }
        private IUiPlayer UiPlayer { get; set; }

        private void Awake()
        {
            CardUtils = transform.parent.GetComponentInChildren<UiCardUtils>();
            UiPlayer = transform.parent.GetComponentInChildren<IUiPlayer>();
        }

        void IPlayerDiscardCard.OnDiscardCard(IPlayer player, IRuntimeCard card)
        {
            if (player.Seat != UiPlayer.Seat)
                return;

            CardUtils.Discard(card);
        }


        // TOOD: it will be removed
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var myPlayer = GameController.Instance.GetPlayerController(PlayerSeat.Bottom).Player;
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
using System.Collections.Generic;
using Patterns;
using SimpleCardGames;
using SimpleCardGames.Battle;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    public class UiCardDrawListener : UiListener, IPlayerDrawCard
    {
        private UiCardUtils CardUtils { get; set; }
        private IUiPlayer UiPlayer { get; set; }

        private void Awake()
        {
            CardUtils = transform.parent.GetComponentInChildren<UiCardUtils>();
            UiPlayer = transform.parent.GetComponentInChildren<IUiPlayer>();
        }

        void IPlayerDrawCard.OnDrawCard(IPlayer player, IRuntimeCard card)
        {
            if (player.Seat != UiPlayer.Seat)
                return;

            CardUtils.Draw(card);
        }
    }
}
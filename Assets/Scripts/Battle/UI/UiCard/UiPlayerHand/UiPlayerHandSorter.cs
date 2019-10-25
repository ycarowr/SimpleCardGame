using System;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    [RequireComponent(typeof(IUiPlayerHand))]
    public class UiPlayerHandSorter : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        const int OffsetZ = -1;
        IUiPlayerHand PlayerHand { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void Awake()
        {
            PlayerHand = GetComponent<IUiPlayerHand>();
            PlayerHand.OnPileChanged += Sort;
        }

        //--------------------------------------------------------------------------------------------------------------

        public void Sort(IUiCard[] cards)
        {
            if (cards == null)
                throw new ArgumentException("Can't sort a card list null");

            var layerZ = 0;
            foreach (var card in cards)
            {
                var localCardPosition = card.transform.localPosition;
                localCardPosition.z = layerZ;
                card.transform.localPosition = localCardPosition;
                layerZ += OffsetZ;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}
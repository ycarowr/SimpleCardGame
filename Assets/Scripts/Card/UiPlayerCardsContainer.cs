using UnityEngine;
using SimpleTurnBasedGame;
using Tools.UI.Card;
using System;

namespace SimpleCardGame
{
    /// <summary>
    ///     Main Card UI. It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    [RequireComponent(typeof(IUiCardHand))]
    public class UiPlayerCardsContainer : MonoBehaviour, IUiPlayer
    {
        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public virtual PlayerSeat Seat => PlayerSeat.Bottom;
        public IGameController GameController => SimpleTurnBasedGame.Controller.GameController.Instance;
        public IPlayerTurn PlayerController => SimpleTurnBasedGame.Controller.GameController.Instance.GetPlayerController(Seat);
        private IUiCardHand Hand { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        private void Awake()
        {
            Hand = GetComponent<IUiCardHand>();
            Hand.OnCardPlayed += OnCardPlayed;
        }

        private void OnDestroy()
        {
            Hand.OnCardPlayed -= OnCardPlayed;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        private void OnCardPlayed(IUiCard card)
        {
            Debug.Log("On Play "+card.Name);
            //PlayerController.ProcessMove()
        }

        //----------------------------------------------------------------------------------------------------------
    }
}
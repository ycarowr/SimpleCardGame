using Tools.UI.Card;
using UnityEngine;

namespace SimpleCardGames.Battle.Controller
{
    /// <summary>
    ///     Main Card UI. It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    [RequireComponent(typeof(IUiCardHand))]
    public class UiCardPlayer : MonoBehaviour, IUiPlayer
    {
        //----------------------------------------------------------------------------------------------------------

        private void OnCardPlayed(IUiCard card)
        {
            
        }

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public virtual PlayerSeat Seat => PlayerSeat.Bottom;
        public IGameController Controller => GameController.Instance;
        public IPlayerTurn PlayerController => GameController.Instance.GetPlayerController(Seat);
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
    }
}
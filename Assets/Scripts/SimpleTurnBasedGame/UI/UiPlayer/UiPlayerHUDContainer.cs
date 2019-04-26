using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Player HUD UI. It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    public class UiPlayerHUDContainer : MonoBehaviour, IUiPlayer
    {
        public virtual PlayerSeat Seat => PlayerSeat.Top;
        public IGameController GameController => Controller.GameController.Instance;
        public IPlayerTurn PlayerController => Controller.GameController.Instance.GetPlayerController(Seat);
    }
}
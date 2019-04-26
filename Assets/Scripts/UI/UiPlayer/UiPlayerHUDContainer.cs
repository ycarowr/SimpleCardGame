using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Player HUD UI. It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    public class UiPlayerHUDContainer : MonoBehaviour, IUiPlayer
    {
        public virtual PlayerSeat Seat => PlayerSeat.Top;
        public IGameController Controller => Battle.Controller.GameController.Instance;
        public IPlayerTurn PlayerController => Battle.Controller.GameController.Instance.GetPlayerController(Seat);
    }
}
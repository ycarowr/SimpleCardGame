using UnityEngine;

namespace SimpleCardGames.Battle.Controller
{
    /// <summary>
    ///     It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    public class UiPlayerUserController : MonoBehaviour, IUiPlayer
    {
        public virtual PlayerSeat Seat => PlayerSeat.Left;
        public IGameController Controller => GameController.Instance;
        public IPlayerTurn PlayerController => GameController.Instance.GetPlayerController(Seat);
    }
}
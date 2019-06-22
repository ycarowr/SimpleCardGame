using SimpleCardGames.Battle.Controller;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Player UI Component. It resolves the dependencies accessing the game controller via Singleton.
    /// </summary>
    public class UiPlayer : MonoBehaviour, IUiPlayer
    {
        public virtual PlayerSeat Seat => PlayerSeat.Right;
        public IGameController Controller => GameController.Instance;
        public IPlayerTurn PlayerController => GameController.Instance.GetPlayerController(Seat);
    }
}
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiAnimationTurn : UiAnimation, IStartPlayerTurn
    {
        [SerializeField] private PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Animate());
        }
    }
}
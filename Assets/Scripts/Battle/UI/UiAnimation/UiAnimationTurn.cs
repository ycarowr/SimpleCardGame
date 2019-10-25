using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiAnimationTurn : UiAnimation, IStartPlayerTurn
    {
        [SerializeField] PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Animate());
        }
    }
}
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiParticlesTurn : UiParticles, IStartPlayerTurn
    {
        [SerializeField] PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Play());
        }
    }
}
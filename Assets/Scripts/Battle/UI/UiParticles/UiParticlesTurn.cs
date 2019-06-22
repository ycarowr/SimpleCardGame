using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiParticlesTurn : UiParticles, IStartPlayerTurn
    {
        [SerializeField] private PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Play());
        }
    }
}
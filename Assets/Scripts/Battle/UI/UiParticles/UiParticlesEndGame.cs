using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiParticlesEndGame : UiParticles, IFinishGame
    {
        private const float DelayToNotify = 1f;
        [SerializeField] private PlayerSeat seat;

        void IFinishGame.OnFinishGame(IPlayer winner)
        {
            if (winner.Seat == seat) StartCoroutine(Play(DelayToNotify));
        }
    }
}
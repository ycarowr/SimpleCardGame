namespace SimpleCardGames.Battle
{
    public class UiParticlesStartGame : UiParticles, IStartGame
    {
        private const float DelayToNotify = 0.75f;

        void IStartGame.OnStartGame(IPlayer player)
        {
            StartCoroutine(Play(DelayToNotify));
        }
    }
}
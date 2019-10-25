using TMPro;

namespace SimpleCardGames.Battle
{
    public class UiAnimationStartGame : UiAnimation, IStartGame
    {
        const float DelayToNotify = 0.75f;
        const string You = "You";
        const string Opp = "Opponent";
        const string S = "s";
        TMP_Text Text;

        void IStartGame.OnStartGame(IPlayer player)
        {
            var txt = player.Seat == PlayerSeat.Left ? You : Opp;
            var plural = player.Seat == PlayerSeat.Left ? string.Empty : S;
            Text.text = txt + " start" + plural + "!";
            StartCoroutine(Animate(DelayToNotify));
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}
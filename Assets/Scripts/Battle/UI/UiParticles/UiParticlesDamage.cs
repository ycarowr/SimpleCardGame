namespace SimpleCardGames.Battle
{
    public class UiParticlesDamage : UiParticles, IDoDamage
    {
        private IUiPlayer Ui { get; set; }

        void IDoDamage.OnDamage(IDamager source, IDamageable target, int amount)
        {
            var player = target as IPlayer;
            if (player.Seat == Ui.Seat)
                StartCoroutine(Play());
        }

        protected override void Awake()
        {
            base.Awake();
            Ui = GetComponentInParent<IUiPlayer>();
        }
    }
}
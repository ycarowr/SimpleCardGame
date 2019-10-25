namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Mana Mechanics.
    /// </summary>
    public class ManaMechanics : BasePlayerMechanics
    {
        public ManaMechanics(IPlayer player) : base(player)
        {
            MaxMana = player.Configurations.MaxMana;
            Mana = MaxMana;
        }

        public int Mana { get; private set; }
        public int MaxMana { get; }

        public void ReplenishMana()
        {
            var delta = MaxMana - Mana;
            Mana = MaxMana;
            OnChangeMana(Player, delta);
        }

        public void ConsumeMana(int amount)
        {
            if (!HasMana(amount))
                return;

            Mana -= amount;
            OnChangeMana(Player, amount);
        }

        public bool HasMana(int amount) => amount <= Mana;

        /// <summary>
        ///     Dispatch to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        void OnChangeMana(IPlayer player, int amount) =>
            GameEvents.Instance.Notify<IDoManaManipulation>(i => i.OnChangeMana(player, amount));
    }
}
using SimpleCardGames.Data.Character;

namespace SimpleCardGames.Battle
{
    public class CharAttributes
    {
        //----------------------------------------------------------------------------------------------------------

        public CharAttributes(ICharacterData data, IPlayer owner)
        {
            SetData(data, owner);
        }

        public int DefaultMaxHealth { get; private set; }

        public bool IsFullHealth => Health == DefaultMaxHealth;

        public ICharacterData CharacterData { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public bool IsDead { get; set; }

        public IPlayer Owner { get; set; }

        public void SetData(ICharacterData data, IPlayer owner)
        {
            CharacterData = data;
            MaxHealth = data.Health;
            Health = data.Health;
            Owner = owner;
            DefaultMaxHealth = Owner.Configurations.Amount.HealthPlayers.GetHealth(owner.Seat);
            Health = DefaultMaxHealth;
        }
    }
}
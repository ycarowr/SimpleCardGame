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

        public bool IsFullHealth => Health == MaxHealth;

        public ICharacterData CharacterData { get; set; }

        public bool HasTaunt { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int MaxAttackPerTurn { get; set; }

        public bool IsDead => Health <= 0;

        public IPlayer Owner { get; set; }

        public int Attack { get; set; }

        public bool HasSummoningSickness { get; set; }

        public bool IsCaptain => Owner.Team.Captain?.Attributes == this;

        public void SetData(ICharacterData data, IPlayer owner)
        {
            CharacterData = data;
            Attack = data.Attack;
            MaxHealth = data.Health;
            Health = MaxHealth;
            MaxAttackPerTurn = data.AttacksTurn;
            HasTaunt = CharacterData.HasTaunt;
            Owner = owner;
            HasSummoningSickness = true;
        }
    }
}
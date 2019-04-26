using Patterns;
using SimpleCardGames.Battle;

namespace SimpleCardGames.Infrastructure
{
    public class PlayerBuilder : DataBuilder<Player>
    {
        private PlayerSeat defaultSeat = PlayerSeat.Bottom;

        public PlayerBuilder(PlayerSeat seat)
        {
            defaultSeat = seat;
        }

        public PlayerBuilder() : this(PlayerSeat.Bottom)
        {
        }

        public PlayerBuilder WithSeat(PlayerSeat seat)
        {
            defaultSeat = seat;
            return this;
        }

        public override Player Build()
        {
            return new Player(defaultSeat);
        }
    }
}
using Patterns;
using SimpleCardGames.Battle;

namespace SimpleCardGames.Infrastructure
{
    public class PlayerBuilder : DataBuilder<Player>
    {
        PlayerSeat defaultSeat = PlayerSeat.Left;

        public PlayerBuilder(PlayerSeat seat) => defaultSeat = seat;

        public PlayerBuilder() : this(PlayerSeat.Left)
        {
        }

        public PlayerBuilder WithSeat(PlayerSeat seat)
        {
            defaultSeat = seat;
            return this;
        }

        public override Player Build() => new Player(defaultSeat);
    }
}
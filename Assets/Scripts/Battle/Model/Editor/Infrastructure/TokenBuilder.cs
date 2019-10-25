using System.Collections.Generic;
using Patterns;
using SimpleCardGames.Battle;

namespace SimpleCardGames.Infrastructure
{
    public class TokenBuilder : DataBuilder<ProcessTurn>
    {
        PlayerSeat currentIndex;
        List<IPlayer> defaultPlayers;
        PlayerSeat startIndex;

        public TokenBuilder(List<IPlayer> players) => defaultPlayers = players;

        public TokenBuilder() : this(new List<IPlayer> {(Player) A.Player()})
        {
        }

        public TokenBuilder WithPlayers(List<IPlayer> players)
        {
            defaultPlayers = players;
            return this;
        }

        public TokenBuilder WithStartSeat(PlayerSeat start)
        {
            startIndex = start;
            return this;
        }

        public TokenBuilder WithCurrentSeat(PlayerSeat current)
        {
            currentIndex = current;
            return this;
        }

        public override ProcessTurn Build() => new ProcessTurn(defaultPlayers, startIndex, currentIndex);
    }
}
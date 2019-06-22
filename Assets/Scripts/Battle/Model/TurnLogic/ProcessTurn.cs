using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     This class decides which player goes first and which player goes next.
    ///     In order to accomplish it, it keeps track of the current player.
    ///     The implementation is done using a single index iterating over a list of players.
    /// </summary>
    public class ProcessTurn : ITurnLogic
    {
        #region Constructor

        public ProcessTurn(
            List<IPlayer> players,
            PlayerSeat start = PlayerSeat.Left,
            PlayerSeat current = PlayerSeat.Left)
        {
            if (players == null)
                throw new ArgumentException("A Null List is not a valid argument to Create a TurnLogic");
            if (players.Count < 1)
                throw new ArgumentException("Invalid number of players: " + players.Count);

            Players = players;
            TurnCount = 0;
            StarterPlayerSeat = start;
            CurrentPlayerSeat = current;
        }

        #endregion

        #region Properties

        public PlayerSeat CurrentPlayerSeat { get; private set; }

        public PlayerSeat NextPlayerSeat =>
            CurrentPlayer.Seat == PlayerSeat.Left ? PlayerSeat.Right : PlayerSeat.Left;

        public PlayerSeat StarterPlayerSeat { get; private set; }

        public List<IPlayer> Players { get; }
        public int TurnCount { get; private set; }

        public IPlayer CurrentPlayer => GetPlayer(CurrentPlayerSeat);
        public IPlayer NextPlayer => GetPlayer(NextPlayerSeat);
        public IPlayer StarterPlayer => GetPlayer(StarterPlayerSeat);

        public int QuantPlayers => Players.Count;

        bool ITurnLogic.IsMyTurn(IPlayer player)
        {
            return CurrentPlayer == player;
        }

        #endregion

        #region Operations

        /// <summary>
        ///     Assign next player to the current player.
        /// </summary>
        public void UpdateCurrentPlayer()
        {
            //increment turn count
            TurnCount++;

            //not on the first turn of the match
            if (TurnCount == 1)
                return;

            //update current player
            CurrentPlayerSeat = NextPlayerSeat;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Decides which player goes first Randomly.
        /// </summary>
        public void DecideStarterPlayer()
        {
            var randomIndex = Random.Range(0, QuantPlayers);
            randomIndex = 0;
            StarterPlayerSeat = Players[randomIndex].Seat;
            CurrentPlayerSeat = StarterPlayerSeat;
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            return player.Seat == PlayerSeat.Left ? GetPlayer(PlayerSeat.Right) : GetPlayer(PlayerSeat.Left);
        }

        public IPlayer GetPlayer(PlayerSeat seat)
        {
            foreach (var player in Players)
                if (player.Seat == seat)
                    return player;

            return null;
        }

        public void SetCurrentSeat(PlayerSeat current)
        {
            CurrentPlayerSeat = current;
        }

        public void SetStarterSeat(PlayerSeat first)
        {
            StarterPlayerSeat = first;
        }

        #endregion
    }
}
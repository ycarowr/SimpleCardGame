using SimpleCardGames;
using SimpleCardGames.Battle;
using SimpleCardGames.Data.Deck;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete player class.
    /// </summary>
    public class Player : IPlayer
    {
        public Player(PlayerSeat seat, Configurations configurations = null)
        {
            Configurations = configurations;
            Seat = seat;
        }

        //----------------------------------------------------------------------------------------------------------

        public BaseDeckData DeckData { get; private set; }

        public IBoard Board { get; private set; }

        public ILibrary Library { get; private set; }

        public ITeam Team { get; private set; }

        public Collection<IRuntimeCard> Hand { get; private set; }

        public Configurations Configurations { get; }

        public PlayerSeat Seat { get; }

        //----------------------------------------------------------------------------------------------------------

        void IPlayer.FinishTurn()
        {
        }

        void IPlayer.StartTurn()
        {
        }

        //----------------------------------------------------------------------------------------------------------

       
    }
}
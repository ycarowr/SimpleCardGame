using SimpleCardGames.Data.Character;
using SimpleCardGames.Data.Deck;
using Tools;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     A concrete player class.
    /// </summary>
    public class Player : IPlayer
    {
        public Player(PlayerSeat seat, TeamData teamData = null, BaseDeckData deckData = null, Configurations configurations = null)
        {
            Configurations = configurations;
            Seat = seat;

            if (teamData != null)
                Team = teamData.GetMembers(this);

            Debug.Log("Team Created "+ Seat);

            if (deckData != null)
                Library = new Library(this, deckData, Configurations);
        }

        //----------------------------------------------------------------------------------------------------------

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
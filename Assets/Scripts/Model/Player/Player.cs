using System;
using Extensions;
using SimpleCardGames.Data.Character;
using SimpleCardGames.Data.Deck;
using Tools;
using UnityEngine;
using SimpleCardGames.Data.Effects;

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

            Hand = new Collection<IRuntimeCard>();

            if (teamData != null)
                Team = teamData.GetMembers(this);

            if (deckData != null)
                Library = new Library(this, deckData, Configurations);

            #region Mechanics

            DrawMechanics = new DrawMechanics(this);
            DiscardMechanics = new DiscardMechanics(this);
            PlayCardMechanics = new PlayCardMechanics(this);
            StartTurnMechanics = new StartTurnMechanics(this);
            FinishTurnMechanics = new FinishTurnMechanics(this);

            #endregion
        }

        //----------------------------------------------------------------------------------------------------------

        public ILibrary Library { get; private set; }

        public ITeam Team { get; private set; }

        public Collection<IRuntimeCard> Hand { get; private set; }

        public Configurations Configurations { get; }

        public PlayerSeat Seat { get; }

        //----------------------------------------------------------------------------------------------------------

        #region Draw 

        public DrawMechanics DrawMechanics { get; }

        void IPlayer.DrawStartingHand()
        {
            DrawMechanics.DrawStartingHand();
        }

        void IDrawable.DoDraw(int amount, IEffector source)
        {
            DrawMechanics.DoDraw(amount, source);
        }

        public bool Draw()
        {
            return DrawMechanics.Draw();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Discard 

        public DiscardMechanics DiscardMechanics { get; }

        void IDiscardable.DoDiscard(int amount, Data.Effects.IEffector source)
        {
            DiscardMechanics.DoDiscard(amount, source);
        }

        public bool Discard(IRuntimeCard card)
        {
            return DiscardMechanics.Discard(card);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Play

        public PlayCardMechanics PlayCardMechanics { get; }

        bool IPlayer.Play(IRuntimeCard card)
        {
            return PlayCardMechanics.Play(card);
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Turn
        
        public StartTurnMechanics StartTurnMechanics { get; }
        public FinishTurnMechanics FinishTurnMechanics { get; }

        void IPlayer.FinishTurn()
        {
            FinishTurnMechanics.FinishTurn();
        }

        void IPlayer.StartTurn()
        {
            StartTurnMechanics.StartTurn();
        }

        #endregion
    }
}
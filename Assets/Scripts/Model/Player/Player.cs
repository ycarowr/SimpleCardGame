using System;
using Extensions;
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

            Hand = new Collection<IRuntimeCard>();

            if (teamData != null)
                Team = teamData.GetMembers(this);

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

        void IPlayer.DrawStartingHand()
        {
            var quant = Configurations.Amount.LibraryPlayer.startingAmount;
            for (int i = 0; i < quant; i++)
                Draw(); 
        }

        void IDrawable.DoDraw(int amount, Data.Effects.IEffector source)
        {
            for (var i = 0; i < amount; i++)
                Draw();
        }

        public bool Draw()
        {
            if (Library == null)
                return false;

            var card = Library.DrawTop();
            card.Draw();
            Hand.Add(card);
            OnDrawCard(this, card);
            return true;
        }

        //----------------------------------------------------------------------------------------------------------

        void IDiscardable.DoDiscard(int amount, Data.Effects.IEffector source)
        {
            for (var i = 0; i < amount; i++)
            {
                if (Hand.Size <= 0)
                    break;

                var card = Hand.Units.RandomItem();
                Discard(card);
            }
        }

        public bool Discard(IRuntimeCard card)
        {
            var hasCard = Hand.Has(card);
            if (!hasCard)
                return false;
            card.Discard();
            Hand.Remove(card);
            OnDiscardCard(this, card);
            return true;
        }

        //----------------------------------------------------------------------------------------------------------

        bool IPlayer.Play(IRuntimeCard card)
        {
            var hasCard = Hand.Has(card);
            if (!hasCard)
                return false;

            Hand.Remove(card);
            card.Play();
            OnPlayCard(this, card);
            return true;
        }

        //----------------------------------------------------------------------------------------------------------

        void IPlayer.FinishTurn()
        {
            if (Configurations.Amount.LibraryPlayer.isDiscardableHands)
                DiscardAll();
        }

        private void DiscardAll()
        {
            var quant = Hand.Size;
            for (var i = 0; i < quant; i++)
                Discard(Hand.Units[0]);
        }

        void IPlayer.StartTurn()
        {
            var quant = Configurations.Amount.LibraryPlayer.drawAmountByTurn;
            for (int i = 0; i < quant; i++)
                Draw();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Dispatch Events

        /// <summary>
        ///     Dispatch card draw to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void OnDrawCard(Player player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<IPlayerDrawCard>(i => i.OnDrawCard(player, card));

        }

        /// <summary>
        ///     Dispatch card discarded to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void OnDiscardCard(Player player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<IPlayerDiscardCard>(i => i.OnDiscardCard(player, card));
        }

        /// <summary>
        ///     Dispatch card played to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void OnPlayCard(Player player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<IPlayerPlayCard>(i => i.OnPlayCard(player, card));
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
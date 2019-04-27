﻿using SimpleCardGames.Data;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     The Library or Deck interface.
    /// </summary>
    public interface ILibrary
    {
        bool IsFinite { get; }
        void Shuffle();
        IRuntimeCard DrawTop();
        void AddCard(ICardData cardData);
    }
}
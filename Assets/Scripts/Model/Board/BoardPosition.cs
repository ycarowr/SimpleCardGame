using System;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Concrete position on the board.
    /// </summary>
    public class BoardPosition : IBoardPosition
    {
        public bool HasCharacter => Character != null;
        public ICharacter Character { get; private set; }

        public BoardPosition(ICharacter character)
        {
         
        }
        
        public void AddCharacter(ICharacter character)
        {
            if (character == null)
                Debug.LogError("Null is not considered a character on this situation.");

            Character = character;
        }

        public void RemoveCharacter()
        {
            Character = null;
        }
    }
}
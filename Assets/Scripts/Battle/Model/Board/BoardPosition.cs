using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Concrete position on the board.
    /// </summary>
    public class BoardPosition : IBoardPosition
    {
        public BoardPosition(IRuntimeCharacter character)
        {
        }

        public IRuntimeCharacter Character { get; private set; }
        public bool HasCharacter => Character != null;

        public void AddCharacter(IRuntimeCharacter character)
        {
            if (character == null)
                Debug.LogError("Null is not considered a character on this situation.");

            Character = character;
        }

        public void RemoveCharacter() => Character = null;
    }
}
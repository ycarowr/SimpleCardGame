using System.Collections.Generic;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Interface for a group of characters.
    /// </summary>
    public interface ITeam
    {
        IPlayer Owner { get; }
        bool IsEmpty { get; }
        IRuntimeCharacter Captain { get; }
        List<IRuntimeCharacter> Members { get; }
        bool HasTaunt { get; }
        IRuntimeCharacter GetMember(int index);
        void AddMember(IRuntimeCharacter member);
        void RemoveMember(IRuntimeCharacter runtimeCharacter);
    }
}
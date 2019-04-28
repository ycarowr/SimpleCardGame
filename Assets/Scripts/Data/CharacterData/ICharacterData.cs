using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    public interface ICharacterData : IBaseData
    {
        CharacterId Id { get; }
        int Health { get; }
    }
}
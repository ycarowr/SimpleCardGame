using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data
{
    public interface ICardData : IBaseData
    {
        CardId Id { get; }
        CardType CardType { get; }
        EffectsSet Effects { get; }
    }
}
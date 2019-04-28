using SimpleCardGames.Data.Effects;
using UnityEngine;

namespace SimpleCardGames.Data
{
    public interface IBaseData
    {
        string Name { get; }
        string Description { get; }
        Sprite Artwork { get; }
    }
}
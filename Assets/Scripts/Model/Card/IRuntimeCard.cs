using SimpleCardGames.Data;
using UnityEngine;

namespace SimpleCardGames
{
    public interface IRuntimeCard
    {
        ICardData Data { get; }
        void Play();
    }
}
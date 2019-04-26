using SimpleCardGame.Data;
using UnityEngine;

namespace SimpleCardGame
{
    public interface IRuntimeCard
    {
        ICardData Data { get; }
        void Play();
    }
}
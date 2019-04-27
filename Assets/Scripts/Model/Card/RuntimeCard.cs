using SimpleCardGames.Data;
using UnityEngine;

namespace SimpleCardGames
{
    /// <summary>
    ///     A card at the runtime.
    /// </summary>
    public class RuntimeCard : IRuntimeCard
    {
        public RuntimeCard(ICardData data)
        {
            Debug.Log("Runtime Card: "+data.CardName + " Created");
            SetData(data);
        }

        /// <summary>
        ///     Reference for all card data.
        /// </summary>
        public ICardData Data { get; private set; }

        /// <summary>
        ///     Set the data inside a card.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICardData data)
        {
            Data = data;
        }

        /// <summary>
        ///     Called when it is drawn.
        /// </summary>
        public void Draw()
        {
            Debug.Log("Draw "+ Data.CardName);
        }

        /// <summary>
        ///     Called when it is played.
        /// </summary>
        public void Play()
        {
            Debug.Log("Play " + Data.CardName);
        }

        /// <summary>
        ///     Called when it is discarded.
        /// </summary>
        public void Discard()
        {
            Debug.Log("Discard " + Data.CardName);
        }
    }
}
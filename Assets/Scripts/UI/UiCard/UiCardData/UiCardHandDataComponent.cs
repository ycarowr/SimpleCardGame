using System;
using UnityEngine;

namespace SimpleCardGames.Data
{
    //--------------------------------------------------------------------------------------------------------------

    public interface ICardHandData
    {
        IRuntimeCard Card { get; }
        ICardData Data { get; }
        Action<ICardData> OnSetData { get; set; }
        void SetCard(IRuntimeCard card);
    }

    //--------------------------------------------------------------------------------------------------------------

    public class UiCardHandDataComponent : MonoBehaviour, ICardHandData
    {
        //--------------------------------------------------------------------------------------------------------------

        public void SetCard(IRuntimeCard card)
        {
            Card = card;
            OnSetData?.Invoke(Data);
        }

        public ICardData Data => Card.Data;
        public Action<ICardData> OnSetData { get; set; } = data => { };
        public IRuntimeCard Card { get; set; }
    }
}
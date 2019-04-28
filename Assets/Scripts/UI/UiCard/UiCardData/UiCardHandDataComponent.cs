using System;
using UnityEngine;

namespace SimpleCardGames.Data
{
    //--------------------------------------------------------------------------------------------------------------

    public interface ICardHandData
    {
        IRuntimeCard RuntimeCard { get; }
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
            RuntimeCard = card;
            OnSetData?.Invoke(Data);
        }

        public ICardData Data => RuntimeCard.Data;
        public Action<ICardData> OnSetData { get; set; } = data => { };
        public IRuntimeCard RuntimeCard { get; set; }
    }
}
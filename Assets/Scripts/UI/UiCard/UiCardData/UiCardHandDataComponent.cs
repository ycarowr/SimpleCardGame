using System;
using SimpleCardGames.Data;
using UnityEngine;

namespace SimpleCardGames
{
    //--------------------------------------------------------------------------------------------------------------

    #region Interface

    public interface ICardHandDataHandler
    {
        CardData Data { get; }
        Action<CardData> OnSetData { get; set; }
        void SetData(CardData data);
    }

    #endregion

    //--------------------------------------------------------------------------------------------------------------

    public class UiCardHandDataComponent : MonoBehaviour, ICardHandDataHandler
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void SetData(CardData data)
        {
            Data = data;
            OnSetData?.Invoke(Data);
        }

        #endregion

        #region Properties

        public CardData Data { get; private set; }
        public Action<CardData> OnSetData { get; set; } = data => { };

        #endregion
    }
}
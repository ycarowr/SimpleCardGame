using SimpleCardGames.Data;
using System;
using UnityEngine;

namespace SimpleCardGames
{
    //--------------------------------------------------------------------------------------------------------------
    
    #region Interface

    public interface ICardHandDataHandler
    {
        CardData Data { get; }
        void SetData(CardData data);
        Action<CardData> OnSetData { get; set; }
    }

    #endregion
    
    //--------------------------------------------------------------------------------------------------------------

    public class UiCardHandDataComponent : MonoBehaviour, ICardHandDataHandler
    {
        #region Properties
        
        public CardData Data { get; private set; }
        public Action<CardData> OnSetData { get; set; } = (data) => {};

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------

        #region Operations


        public void SetData(CardData data)
        {
            Data = data;
            OnSetData?.Invoke(Data);
        }

        #endregion
       
    }
}
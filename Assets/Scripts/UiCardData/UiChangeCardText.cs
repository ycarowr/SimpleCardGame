using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleCardGame
{
    public abstract class UiChangeCardText : UiText3D
    {
        protected ICardHandDataHandler Handler { get; set; }
        
        private void OnSetData(CardData data)
        {
            SetText(GetText());   
        }

        protected override void Awake()
        {
            base.Awake();
            Handler = GetComponentInParent<ICardHandDataHandler>();
            Handler.OnSetData += OnSetData;
        }

        private void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }

        protected abstract string GetText();
    }
}

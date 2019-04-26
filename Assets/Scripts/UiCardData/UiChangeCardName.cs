using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleCardGame
{
    public class UiChangeCardName : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.Data.CardName;
        }
    }
}

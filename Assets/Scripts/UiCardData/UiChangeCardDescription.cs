using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleCardGame
{
    public class UiChangeCardDescription : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.Data.CardDescription;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleCardGames
{
    public class UiChangeCardName : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.Data.CardName;
        }
    }
}

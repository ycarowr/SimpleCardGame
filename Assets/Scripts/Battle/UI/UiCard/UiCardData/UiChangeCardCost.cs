namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardCost : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.StaticData.CardCost.ToString();
        }
    }
}
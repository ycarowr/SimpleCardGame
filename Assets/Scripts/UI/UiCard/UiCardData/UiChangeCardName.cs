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
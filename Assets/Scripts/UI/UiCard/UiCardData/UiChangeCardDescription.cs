namespace SimpleCardGames
{
    public class UiChangeCardDescription : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.Data.Description;
        }
    }
}
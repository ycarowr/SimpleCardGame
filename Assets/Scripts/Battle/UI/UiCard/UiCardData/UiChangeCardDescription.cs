namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardDescription : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.StaticData.Description;
        }
    }
}
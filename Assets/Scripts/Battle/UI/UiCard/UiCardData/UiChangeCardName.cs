namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardName : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.StaticData.Name;
        }
    }
}
namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardName : UiChangeCardText
    {
        protected override string GetText() => Handler.StaticData.Name;
    }
}
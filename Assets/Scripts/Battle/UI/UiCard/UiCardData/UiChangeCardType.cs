namespace SimpleCardGames.Data.Card
{
    public class UiChangeCardType : UiChangeCardText
    {
        protected override string GetText()
        {
            return Handler.StaticData.CardType.ToString();
        }
    }
}
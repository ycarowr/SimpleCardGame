namespace SimpleCardGames.Battle.UI.Character
{
    public class UiChangeCharacterName : UiChangeCharacterText
    {
        protected override string GetText()
        {
            return Handler.StaticData.Name;
        }
    }
}
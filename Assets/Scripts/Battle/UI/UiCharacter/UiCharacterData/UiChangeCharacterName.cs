namespace SimpleCardGames.Battle.UI.Character
{
    public class UiChangeCharacterName : UiChangeCharacterText
    {
        protected override string GetText() => Handler.StaticData.Name;
    }
}
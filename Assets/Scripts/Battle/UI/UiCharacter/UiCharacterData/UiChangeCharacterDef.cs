namespace SimpleCardGames.Battle.UI.Character
{
    public class UiChangeCharacterDef : UiChangeCharacterText
    {
        private const string Def = "Def: ";

        protected override string GetText()
        {
            return ""; // Def + Handler.Data.Defense;
        }
    }
}
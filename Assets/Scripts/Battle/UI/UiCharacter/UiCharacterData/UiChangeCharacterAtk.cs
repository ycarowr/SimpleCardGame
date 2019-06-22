namespace SimpleCardGames.Battle.UI.Character
{
    public class UiChangeCharacterAtk : UiChangeCharacterText
    {
        private const string Atk = "Atk: ";

        protected override string GetText()
        {
            return Atk + Handler.StaticData.Attack;
        }
    }
}
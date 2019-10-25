namespace SimpleCardGames.Battle.UI.Character
{
    public class UiChangeCharacterAtk : UiChangeCharacterText
    {
        const string Atk = "Atk: ";

        protected override string GetText() => Atk + Handler.StaticData.Attack;
    }
}
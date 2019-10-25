namespace SimpleCardGames.Battle.UI.Character
{
    public class UiChangeCharacterHealth : UiChangeCharacterText, IDoDamage, IDoHeal, IDoAttack
    {
        const string Health = "Health: ";

        void IDoAttack.OnCantAttack(IDamager source, IDamageable target, int amount)
        {
            //
        }

        void IDoAttack.OnDamage(IDamager source, IDamageable target, int amount) =>
            CheckHealth(target as IRuntimeCharacter);

        void IDoDamage.OnDamage(IDamager source, IDamageable target, int amount) =>
            CheckHealth(target as IRuntimeCharacter);

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount) => CheckHealth(target as IRuntimeCharacter);

        protected override string GetText() => Health + Handler.RuntimeData.Attributes.Health;

        void CheckHealth(IRuntimeCharacter target)
        {
            if (!IsMyData(target))
                return;

            SetText(GetText());
        }
    }
}
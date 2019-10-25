using TMPro;

namespace SimpleCardGames.Battle
{
    public class UiAnimationHeal : UiAnimation, IDoHeal
    {
        TMP_Text Text { get; set; }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            Text.text = Localization.Instance.Get(LocalizationIds.Heal) + "+" + amount;
            StartCoroutine(Animate());
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}
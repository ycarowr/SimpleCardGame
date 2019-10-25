using UnityEngine;

namespace SimpleCardGames
{
    public class UiGuiTextButtonDamage : UiGUIText
    {
        [SerializeField] Configurations configurations;

        int MaxDamage => configurations.Amount.Damage.MaxDamage;
        int MinDamage => configurations.Amount.Damage.MinDamage;

        protected override void Awake()
        {
            base.Awake();
            var damageText = Localization.Instance.Get(LocalizationIds.Damage);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{MinDamage}-{MaxDamage - 1}] {damageText} {moveText}");
        }
    }
}
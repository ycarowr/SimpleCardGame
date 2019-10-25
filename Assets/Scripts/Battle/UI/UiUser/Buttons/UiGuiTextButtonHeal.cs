using UnityEngine;

namespace SimpleCardGames
{
    public class UiGuiTextButtonHeal : UiGUIText
    {
        [SerializeField] Configurations configurations;

        int MaxHeal => configurations.Amount.Heal.MaxHeal;
        int MinHeal => configurations.Amount.Heal.MinHeal;

        protected override void Awake()
        {
            base.Awake();
            var healText = Localization.Instance.Get(LocalizationIds.Heal);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{MinHeal}-{MaxHeal - 1}] {healText} {moveText}");
        }
    }
}
using UnityEngine;

namespace SimpleCardGames
{
    public class UiGuiTextButtonRandom : UiGUIText
    {
        [SerializeField] Configurations configurations;
        int Bonus => configurations.Amount.Bonus.Value;

        protected override void Awake()
        {
            base.Awake();
            var randomText = Localization.Instance.Get(LocalizationIds.Random);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText(randomText + " " + moveText + " +" + Bonus);
        }
    }
}
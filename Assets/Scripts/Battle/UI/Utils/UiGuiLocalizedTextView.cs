using UnityEngine;

namespace SimpleCardGames
{
    public class UiGuiLocalizedTextView : UiGUIText
    {
        [SerializeField] LocalizationIds id;

        protected override void Awake()
        {
            base.Awake();
            SetText(Localization.Instance.Get(id));
        }
    }
}
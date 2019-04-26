using UnityEngine;

namespace SimpleCardGames
{
    public class UiGuiLocalizedTextView : UiGUIText
    {
        [SerializeField] private LocalizationIds id;

        protected override void Awake()
        {
            base.Awake();
            SetText(Localization.Instance.Get(id));
        }
    }
}
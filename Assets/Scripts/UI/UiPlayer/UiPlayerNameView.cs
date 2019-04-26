using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiPlayerNameView : MonoBehaviour
    {
        private string PlayerText { get; set; }
        private UiGUIText UiGuiText { get; set; }
        private IUiPlayer Ui { get; set; }

        private void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UiGuiText = GetComponent<UiGUIText>();
            PlayerText = Localization.Instance.Get(LocalizationIds.Player);
        }

        private void Start()
        {
            UiGuiText.SetText(PlayerText + ": " + Ui.Seat);
        }
    }
}
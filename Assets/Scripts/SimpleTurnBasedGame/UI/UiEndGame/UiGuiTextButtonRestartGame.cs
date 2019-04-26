namespace SimpleTurnBasedGame
{
    public class UiGuiTextButtonRestartGame : UiGUIText
    {
        protected override void Awake()
        {
            base.Awake();
            var restartText = Localization.Instance.Get(LocalizationIds.Restart);
            SetText(restartText);
        }
    }
}
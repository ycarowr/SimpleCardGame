namespace SimpleCardGames
{
    public class UiGuiTextButtonFinishBattle : UiGUIText
    {
        protected override void Awake()
        {
            base.Awake();
            var fbTxt = Localization.Instance.Get(LocalizationIds.Finish_Battle);
            SetText(fbTxt.Replace("_", " "));
        }
    }
}
namespace SimpleCardGames.Data.Card
{
    public abstract class UiChangeCardText : UiText3D
    {
        protected IUiCardData Handler { get; set; }

        private void OnSetData(ICardData data)
        {
            SetText(GetText());
        }

        protected override void Awake()
        {
            base.Awake();
            Handler = GetComponentInParent<IUiCardData>();
            Handler.OnSetData += OnSetData;
        }

        private void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }

        protected abstract string GetText();
    }
}
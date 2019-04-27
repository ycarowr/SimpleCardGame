using SimpleCardGames.Data;

namespace SimpleCardGames
{
    public abstract class UiChangeCardText : UiText3D
    {
        protected ICardHandData Handler { get; set; }

        private void OnSetData(ICardData data)
        {
            SetText(GetText());
        }

        protected override void Awake()
        {
            base.Awake();
            Handler = GetComponentInParent<ICardHandData>();
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
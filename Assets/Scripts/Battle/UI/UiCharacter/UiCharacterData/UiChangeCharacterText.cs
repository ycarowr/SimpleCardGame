using Patterns;
using SimpleCardGames.Data.Character;

namespace SimpleCardGames.Battle.UI.Character
{
    public abstract class UiChangeCharacterText : UiText3D, IListener
    {
        protected IUiCharacterData Handler { get; set; }

        private void OnSetData(ICharacterData data)
        {
            SetText(GetText());
        }

        protected override void Awake()
        {
            base.Awake();
            Handler = GetComponentInParent<IUiCharacterData>();
            Handler.OnSetData += OnSetData;
        }

        protected virtual void Start()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.AddListener(this);
        }

        private void OnDestroy()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);

            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }

        protected bool IsMyData(IRuntimeCharacter target)
        {
            return target == Handler.RuntimeData;
        }

        protected abstract string GetText();
    }
}
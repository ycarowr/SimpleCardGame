using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    public abstract class UiChangeCardSprite : UiSprite3D
    {
        protected IUiCardData Handler { get; set; }

        private void OnSetData(ICardData data)
        {
            SetSprite(GetSprite(), ShowSprite());
            SetSpriteColor(GetSpriteColor());
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

        protected abstract Color GetSpriteColor();
        protected abstract Sprite GetSprite();
        protected abstract bool ShowSprite();
    }
}
using SimpleCardGames.Data.Card;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class UiChangeCardTexture : MonoBehaviour
    {
        SpriteRenderer MyRenderer { get; set; }
        IUiCardData Handler { get; set; }

        void OnSetData(ICardData data) => SetTexture(data.Artwork);

        void SetTexture(Sprite sprite) => MyRenderer.sprite = sprite;

        void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();
            Handler = GetComponentInParent<IUiCardData>();
            Handler.OnSetData += OnSetData;
        }

        void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }
    }
}
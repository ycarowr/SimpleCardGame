using SimpleCardGames.Data;
using UnityEngine;

namespace SimpleCardGames
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class UiChangeCardTexture : MonoBehaviour
    {
        private SpriteRenderer MyRenderer { get; set; }
        private ICardHandData Handler { get; set; }

        private void OnSetData(ICardData data)
        {
            SetTexture(data.Artwork);
        }

        private void SetTexture(Sprite sprite)
        {
            MyRenderer.sprite = sprite;
        }

        private void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();
            Handler = GetComponentInParent<ICardHandData>();
            Handler.OnSetData += OnSetData;
        }

        private void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }
    }
}
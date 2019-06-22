using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class UiChangeCharacterTexture : MonoBehaviour
    {
        private SpriteRenderer MyRenderer { get; set; }
        private IUiCharacterData Handler { get; set; }

        private void OnSetData(ICharacterData data)
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
            Handler = GetComponentInParent<IUiCharacterData>();
            Handler.OnSetData += OnSetData;
        }

        private void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }
    }
}
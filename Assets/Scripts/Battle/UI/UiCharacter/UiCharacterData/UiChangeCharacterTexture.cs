using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class UiChangeCharacterTexture : MonoBehaviour
    {
        SpriteRenderer MyRenderer { get; set; }
        IUiCharacterData Handler { get; set; }

        void OnSetData(ICharacterData data) => SetTexture(data.Artwork);

        void SetTexture(Sprite sprite) => MyRenderer.sprite = sprite;

        void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();
            Handler = GetComponentInParent<IUiCharacterData>();
            Handler.OnSetData += OnSetData;
        }

        void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }
    }
}
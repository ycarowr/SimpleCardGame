using Tools.UI;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     Main components of an UI card.
    /// </summary>
    public interface IUiCardComponents
    {
        Camera MainCamera { get; }
        MeshRenderer[] MRenderers { get; }
        MeshRenderer MRenderer { get; }
        SpriteRenderer[] Renderers { get; }
        SpriteRenderer Renderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        IMouseInput Input { get; }
        MonoBehaviour MonoBehavior { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}
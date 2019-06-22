using Tools.UI;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    /// <summary>
    ///     Main components of an UI character.
    /// </summary>
    public interface IUiCharacterComponents
    {
        Camera MainCamera { get; }
        SpriteRenderer Renderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        IMouseInput Input { get; }
        MonoBehaviour MonoBehavior { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}
using UnityEngine;

namespace Tools.UI.Card
{
    public interface IUiCardComponents
    {
        UiCardParameters CardConfigsParameters { get; }
        Camera MainCamera { get; }
        IUiCardHand Hand { get; }
        SpriteRenderer[] Renderers { get; }
        SpriteRenderer MyRenderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        IMouseInput Input { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
        MonoBehaviour MonoBehavior { get; }
    }
}
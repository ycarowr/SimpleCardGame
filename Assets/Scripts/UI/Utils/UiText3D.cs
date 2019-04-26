using TMPro;
using UnityEngine;

public class UiText3D : MonoBehaviour
{
    [Tooltip("Color of the text.")] [SerializeField]
    protected Color color = Color.black;

    [SerializeField] private string defaultText = string.Empty;

    [Tooltip("TMPro Component assigned by the Editor or Automatically on Awake.")]
    private TextMeshPro TmProText;

    protected virtual void Awake()
    {
        if (TmProText == null)
            TmProText = GetComponent<TextMeshPro>();

        TmProText.color = color;
        SetText(defaultText);
    }

    public virtual void SetText(string text)
    {
        TmProText.text = text;
    }
}
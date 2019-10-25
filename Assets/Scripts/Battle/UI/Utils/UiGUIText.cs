using TMPro;
using UnityEngine;

public class UiGUIText : MonoBehaviour
{
    [Tooltip("Color of the text.")] [SerializeField]
    protected Color color = Color.black;

    [SerializeField] string defaultText = string.Empty;

    [Tooltip("TMPro Component assigned by the Editor or Automatically on Awake.")]
    TextMeshProUGUI TmProText;

    protected virtual void Awake()
    {
        if (TmProText == null)
            TmProText = GetComponent<TextMeshProUGUI>();

        TmProText.color = color;
        SetText(defaultText);
    }

    public virtual void SetText(string text) => TmProText.text = text;
}
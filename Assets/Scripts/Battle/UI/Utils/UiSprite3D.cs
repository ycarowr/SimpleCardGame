using UnityEngine;

public class UiSprite3D : MonoBehaviour
{
    [Tooltip("SpriteRenderer Component assigned by the Editor or Automatically on Awake.")]
    SpriteRenderer rendy;

    protected virtual void Awake()
    {
        if (rendy == null)
            rendy = GetComponent<SpriteRenderer>();

        ResetSprite();
        SetSpriteColor(Color.white);
    }

    public virtual void SetSprite(Sprite spr, bool show)
    {
        if (spr != null) rendy.sprite = spr;
        rendy.enabled = show;
    }

    public virtual void SetSpriteColor(Color clr) => rendy.color = clr;

    public void ResetSprite()
    {
        if (rendy == null)
            rendy = GetComponent<SpriteRenderer>();
    }
}
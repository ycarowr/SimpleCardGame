﻿using SimpleCardGames.Data;
using UnityEngine;

namespace SimpleCardGames
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class UiChangeCardTexture : MonoBehaviour
    {
        private SpriteRenderer MyRenderer { get; set; }
        private ICardHandDataHandler Handler { get; set; }

        private void OnSetData(CardData data)
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
            Handler = GetComponentInParent<ICardHandDataHandler>();
            Handler.OnSetData += OnSetData;
        }

        private void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IInteractable
{
    public int Value;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public delegate void BallSelectedDelegate(Ball ball);
    public static BallSelectedDelegate OnBallSelected;
    [SerializeField] private SpriteRenderer _highlightSR;
    private bool _selected;
    public int Column;

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void OnInputDown()
    {
        if (_selected)
        {
            return;
        }

        HighlightSelected();
        OnBallSelected?.Invoke(this);
    }

    private void HighlightSelected()
    {
        _highlightSR.enabled = true;
        _selected = true;
    }
}

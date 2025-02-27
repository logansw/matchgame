using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IInteractable
{
    public int Value;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public delegate void BallTappedDelegate(Ball ball);
    public static BallTappedDelegate OnBallSelected;
    public static BallTappedDelegate OnBallTapped;
    [SerializeField] private SpriteRenderer _highlightSR;
    private bool _selected;
    public int Column;

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void OnInputDown()
    {
        OnBallTapped?.Invoke(this);
    }

    public void Deselect()
    {
        _selected = false;
        _highlightSR.enabled = false;
    }

    public void HighlightSelected()
    {
        OnBallSelected.Invoke(this);
        _highlightSR.enabled = true;
        _selected = true;
    }
}

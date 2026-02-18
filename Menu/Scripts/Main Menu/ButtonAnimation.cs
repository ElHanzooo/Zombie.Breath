using Godot;
using System;

public partial class ButtonAnimation : TextureButton
{
    [Export] public float displacement = 25f;
    [Export] public float animationDuration = 0.2f;

    private Tween _tween;

    public override void _Ready()
    {
        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    public void OnMouseEntered()
    {
        _tween?.Kill();
        _tween = GetTree().CreateTween();
        _tween.TweenProperty(this, "position:x", displacement, animationDuration).SetTrans(Tween.TransitionType.Cubic).SetEase(Tween.EaseType.Out);
    }

    public void OnMouseExited()
    {
        _tween?.Kill();
        _tween = GetTree().CreateTween();
        _tween.TweenProperty(this, "position:x", 0f, animationDuration).SetTrans(Tween.TransitionType.Cubic).SetEase(Tween.EaseType.Out);
    }
}

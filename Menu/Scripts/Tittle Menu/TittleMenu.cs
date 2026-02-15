using Godot;
using System;

public partial class TittleMenu : Control
{
    private LogoShake _logoShake;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _logoShake = GetNode<LogoShake>("LogoShake");
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        _animationPlayer.Play("Entry");
    }

    public override void _Process(double delta)
    {
        _logoShake.Shake(delta);
    }
}

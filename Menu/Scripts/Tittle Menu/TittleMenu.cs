using Godot;
using System;

public partial class TittleMenu : Control
{
    [Export] TextureRect _logo;
    [Export] float rotationAmplitude = 3f;
    [Export] float shakeSpeed = 15f;

    private LogoShake _logoShake;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _logoShake = new Shake();
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        _animationPlayer.Play("Entry");
    }

    public override void _Process(double delta)
    {
        _logoShake.Shaking(_logo, rotationAmplitude, shakeSpeed, (float)delta);
    }
}

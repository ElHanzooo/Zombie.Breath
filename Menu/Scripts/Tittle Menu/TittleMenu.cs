using Godot;
using System;

public partial class TittleMenu : Control
{
    [Export] public TextureRect _logo;
    [Export] public float rotationAmplitude = 3f;
    [Export] public float shakeSpeed = 15f;

    private LogoShake _logoShake;
    private StartPressed _startPressed;

    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _logoShake = new Shake();
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _startPressed = GetNode<StartPressed>("StartPressed");

        _animationPlayer.Play("Entry");

        _startPressed.Starting += () => _animationPlayer.Play("Exit");

        _animationPlayer.AnimationFinished += OnAnimationFinished;
    }

    public override void _Process(double delta)
    {
        _logoShake.Shaking(_logo, rotationAmplitude, shakeSpeed, (float)delta);
    }

    private void OnAnimationFinished(StringName animName)
    {
        if (animName == "Exit")
        {
            SceneChanger.Instance.ChangeScene("res://Menu/Scenes/main_menu.tscn");
        }
    }
}

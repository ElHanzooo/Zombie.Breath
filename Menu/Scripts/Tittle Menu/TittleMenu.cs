using Godot;
using System;

public partial class TittleMenu : Control
{
    [Export] private TextureRect _logo;
    [Export] private float rotationAmplitude = 3f;
    [Export] private float shakeSpeed = 15f;

    private IControlEffect _logoShake;

    private StartPressed _startLogic;
    private AnimationPlayer _animationPlayer;
    private AudioStreamPlayer _sfx;

    public override void _Ready()
    {
        MenuMusicPlayer.Instance.PlayMusic();

        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _startLogic = GetNode<StartPressed>("StartPressed");
        _sfx = GetNode<AudioStreamPlayer>("EnterSFX");

        _logoShake = new ShakeEffect(rotationAmplitude, shakeSpeed);

        _startLogic.Starting += HandleStartPressed;
        _animationPlayer.AnimationFinished += OnAnimationFinished;
    }

    public override void _Process(double delta)
    {
        _logoShake?.Apply(_logo, (float)delta);
    }

    private void HandleStartPressed()
    {
        _sfx?.Play();
        _animationPlayer.Play("Exit");
    }

    private void OnAnimationFinished(StringName animName)
    {
        if (animName == "Exit")
        {
            SceneChanger.Instance.ChangeScene("res://Menu/Scenes/main_menu.tscn");
        }
    }
}

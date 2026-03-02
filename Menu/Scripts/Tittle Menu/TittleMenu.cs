using Godot;
using System;

public partial class TittleMenu : Control
{
    [Export] private TextureRect _logo;
    [Export] private float rotationAmplitude = 3f;
    [Export] private float shakeSpeed = 15f;
    [Export] private AudioStreamPlayer _ButtonSFX;
    [Export] private StartPressed _startLogic;
    [Export] private AnimationTree _animationTree;

    private IControlEffect _logoShake;

    private AnimationNodeStateMachinePlayback _animationStateMachine;

    public override void _Ready()
    {
        MenuMusicPlayer.Instance.PlayMusic();

        _logoShake = new ShakeEffect(rotationAmplitude, shakeSpeed);

        _animationStateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");
        _animationTree.Set("parameters/conditions/CBottom", true);
        _animationStateMachine.Travel("RESET");

        _startLogic.Starting += HandleStartPressed;
        _animationTree.AnimationFinished += OnAnimationFinished;
    }

    public override void _Process(double delta)
    {
        _logoShake?.Apply(_logo, (float)delta);
    }

    private void HandleStartPressed()
    {
        _ButtonSFX?.Play();
        _animationTree.Set("parameters/conditions/CBottom", false);
        _animationTree.Set("parameters/conditions/Exit", true);
        _animationStateMachine.Travel("RESET");
    }

    private void OnAnimationFinished(StringName animName)
    {
        if (animName == "Exit")
        {
            SceneChanger.Instance.ChangeScene("res://Menu/Scenes/main_menu.tscn");
        }
    }
}

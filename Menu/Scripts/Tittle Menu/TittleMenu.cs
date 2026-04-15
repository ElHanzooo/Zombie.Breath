using Godot;
using System;

public partial class TittleMenu : Control
{
    [ExportGroup("Logo Shake Configuration")]
    [Export] private TextureRect _logo;
    [Export] private float rotationAmplitude = 3f;
    [Export] private float shakeSpeed = 15f;

    [ExportGroup("Nodes References")]
    [Export] private AudioStreamPlayer _ButtonSFX;
    [Export] private StartPressed _startLogic;
    [Export] private AnimationTree _animationTree;
    [Export] private VideoStreamPlayer _SplashScreen;

    private IControlEffect _logoShake;

    private AnimationNodeStateMachinePlayback _animationStateMachine;

    public override void _Ready()
    {
        _SplashScreen.Visible = true;
        _logoShake = new ShakeEffect(rotationAmplitude, shakeSpeed);

        _animationStateMachine = (AnimationNodeStateMachinePlayback)_animationTree.Get("parameters/playback");
        _animationStateMachine.Travel("RESET");
        
        _SplashScreen.Finished += () =>
        {
            _SplashScreen.Visible = false;
            MenuMusicPlayer.Instance.PlayMusic();

            switch (Global.Instance.Episode)
            {
                case Episodes.Afternoon:
                    _animationStateMachine.Travel("EntryCRight");
                    break;
                default:
                    _animationStateMachine.Travel("EntryCBottom");
                    break;
            }
        };
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
        _animationStateMachine.Travel("RESET");
        _animationStateMachine.Travel("Exit");
    }

    private void OnAnimationFinished(StringName animName)
    {
        if (animName == "Exit")
        {
            SceneChanger.Instance.ChangeScene("res://Menu/Scenes/main_menu.tscn");
        }
    }
}

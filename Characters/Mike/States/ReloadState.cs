using Godot;
using System;

[GlobalClass]
public partial class ReloadState : State
{
    [Export] private Mike Mike { get; set; }

    private AnimatedSprite2D animations;

    public override void _Ready()
    {
        animations = Mike.GetNode<AnimatedSprite2D>("Animations");
    }

    public override void Enter()
    {
        animations.Play("Reload");
        animations.AnimationFinished += OnAnimationFinished;

        Global.Instance.PlaySFX(GD.Load<AudioStream>("res://Characters/Mike/Assets/SFXs/Reload.ogg"));
    }

    public override void Exit()
    {
        animations.AnimationFinished -= OnAnimationFinished;
        Mike.NeedReload = false;
    }

    private void OnAnimationFinished()
    {
        EmitSignal(SignalName.Transitioned, "Idle");
    }
}
using Godot;
using System;

[GlobalClass]
public partial class ShootState : State
{
    [Export] private Mike Mike { get; set; }

    private AnimatedSprite2D animations;

    public override void _Ready()
    {
        animations = Mike.GetNode<AnimatedSprite2D>("Animations");
    }

    public override void Enter()
    {
        animations.Play("Shoot");
        animations.AnimationFinished += OnAnimationFinished;

        Global.Instance.PlaySFX(GD.Load<AudioStream>("res://Characters/Mike/Assets/SFXs/Shoot.ogg"));
    }

    public override void Exit()
    {
        animations.AnimationFinished -= OnAnimationFinished;
        Mike.NeedReload = true;
    }

    private void OnAnimationFinished()
    {
        EmitSignal(SignalName.Transitioned, "Idle");
    }
}
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
        animations.AnimationFinished += () => EmitSignal(SignalName.Transitioned, "Idle");
    }

    public override void Enter()
    {
        animations.Play("Shoot");
        Global.Instance.PlaySFX(GD.Load<AudioStream>("res://Characters/Mike/Assets/SFXs/Shoot.ogg"));
    }
}

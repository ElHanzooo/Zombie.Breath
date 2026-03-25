using Godot;
using System;

[GlobalClass]
public partial class UpState : State
{
    [Export] private Mike Mike { get; set; }

    private AnimatedSprite2D animations;

    public override void _Ready()
    {
        animations = Mike.GetNode<AnimatedSprite2D>("Animations");
    }

    public override void Enter()
    {
        animations.Play("Up");
        animations.AnimationFinished += OnAnimationFinished;
    }

    public override void Update(double delta)
    {
        if (Input.IsActionJustReleased("Up"))
            EmitSignal(SignalName.Transitioned, "Idle");
    }

    public override void Exit()
    {
        animations.AnimationFinished -= OnAnimationFinished;
    }

    private void OnAnimationFinished()
    {
        animations.Frame = 2;
    }
}
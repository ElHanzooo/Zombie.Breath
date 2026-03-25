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
        if (Mike.IsLookingUp)
        {
            animations.Animation = "Up";
            animations.Frame = 3;
        }
        else
            animations.Play("Up");

        animations.AnimationFinished += OnAnimationFinished;
        Mike.IsLookingUp = true;
    }

    public override void Update(double delta)
    {
        if (Input.IsActionJustReleased("Up"))
        {
            Mike.IsLookingUp = false;
            EmitSignal(SignalName.Transitioned, "Idle");
        }

        if (Input.IsActionJustPressed("Shoot") && !Mike.NeedReload)
            EmitSignal(SignalName.Transitioned, "UpShoot");
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
using Godot;
using System;

[GlobalClass]
public partial class UpShootState : State
{
    [Export] private Mike Mike { get; set; }

    private AnimatedSprite2D animations;

    public override void _Ready()
    {
        animations = Mike.GetNode<AnimatedSprite2D>("Animations");
    }

    public override void Enter()
    {
        animations.Play("Up Shoot");
        animations.AnimationFinished += OnAnimationFinished;

        Global.Instance.PlaySFX(GD.Load<AudioStream>("res://Characters/Mike/Assets/SFXs/Shoot.ogg"));
    }

    public override void Update(double delta)
    {
        if (Input.IsActionJustReleased("Up"))
        {
            Mike.IsLookingUp = false;
        }
    }

    public override void Exit()
    {
        animations.AnimationFinished -= OnAnimationFinished;
        Mike.NeedReload = true;
    }

    private void OnAnimationFinished()
    {
        if (Mike.IsLookingUp)
            EmitSignal(SignalName.Transitioned, "Up");
        else
            EmitSignal(SignalName.Transitioned, "Idle");
    }
}
using Godot;
using System;

[GlobalClass]
public partial class IdleState : State
{
    [Export] private Mike Mike { get; set; }

    private AnimatedSprite2D animations;

    public override void _Ready()
    {
        animations = Mike.GetNode<AnimatedSprite2D>("Animations");
    }

    public override void Enter()
    {
        animations.Play("Idle");
    }

    public override void Update(double delta)
    {
        if (Input.IsActionJustPressed("Shoot") && !Mike.NeedReload)
            EmitSignal(SignalName.Transitioned, "Shoot");

        if (Input.IsActionJustPressed("Reload") && Mike.NeedReload)
            EmitSignal(SignalName.Transitioned, "Reload");
    }
}

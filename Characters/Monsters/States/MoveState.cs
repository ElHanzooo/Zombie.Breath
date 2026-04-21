using Godot;
using System;

[GlobalClass]
public partial class MoveState : State
{
    [Export] private Zumbi Zumbi { get; set; }

    private AnimatedSprite2D sprites;

    public override void _Ready()
    {
        sprites = Zumbi.GetNode<AnimatedSprite2D>("Sprites");
    }

    public override void Enter()
    {
        sprites.Play("Walk");
    }

    public override void Update(double delta)
    {
        Zumbi.Position += Vector2.Left * Zumbi.Speed;
    }
}

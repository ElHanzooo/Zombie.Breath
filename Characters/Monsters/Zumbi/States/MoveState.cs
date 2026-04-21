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
        sprites.SpriteFrames = GD.Load<SpriteFrames>($"res://Characters/Monsters/Zumbi/Assets/Sprites/Type {Random.Shared.Next(1, 6)}/SpriteFrames.tres");
        sprites.Play("Walk");
        
        Global.Instance.PlaySFX(GD.Load<AudioStream>($"res://Characters/Monsters/Zumbi/Assets/Sound Effects/Default/Default {Random.Shared.Next(1, 7)}.ogg"));
    }

    public override void Update(double delta)
    {
        Zumbi.Position += Vector2.Left * Zumbi.Speed;
    }
}

using Godot;
using System;

public partial class Gameplay : Node2D
{
    [Export] private CanvasLayer Background { get; set; }
    [Export] private CanvasLayer Characters { get; set; }

    public override void _Ready()
    {
        var background = Background.GetNode<AnimatedSprite2D>("Background");
        background.Position = GetViewportRect().GetCenter();

        var mike = Characters.GetNode<Area2D>("Mike");
        mike.Position = new Vector2(135, 495);
    }
}

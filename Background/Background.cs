using Godot;
using System;

public partial class Background : AnimatedSprite2D
{
    public override void _Process(double delta)
    {
        Animation = $"Act {Global.Instance.Act} - {Global.Instance.Episode}";
        Play();
    }
}

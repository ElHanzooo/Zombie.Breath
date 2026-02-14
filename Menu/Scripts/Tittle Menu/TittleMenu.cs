using Godot;
using System;

public partial class TittleMenu : Control
{
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        _animationPlayer.Play("Entry");
    }

}

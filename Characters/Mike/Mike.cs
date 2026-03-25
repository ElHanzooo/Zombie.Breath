using Godot;
using System;

public partial class Mike : Area2D
{
    public bool NeedReload = false;
    public bool IsLookingUp = false;

    public override void _Process(double delta)
    {
        GD.Print(IsLookingUp);
    }
}

using Godot;
using System;

public partial class BackCMAction : ButtonAction
{
    [Signal] public delegate void BackPressedEventHandler();

    public override void Execute()
    {
        EmitSignal(SignalName.BackPressed);
    }
}
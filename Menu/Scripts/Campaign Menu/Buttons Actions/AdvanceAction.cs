using Godot;
using System;

public partial class AdvanceAction : ButtonAction
{
    [Signal] public delegate void AdvancePressedEventHandler();

    public override void Execute()
    {
        EmitSignal(SignalName.AdvancePressed);
    }
}
using Godot;
using System;

public partial class OptionsAction : ButtonAction
{
    [Signal] public delegate void OpenOptionsEventHandler();

    public override void Execute()
    {
        EmitSignal(SignalName.OpenOptions);
    }
}

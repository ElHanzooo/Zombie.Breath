using Godot;
using System;

public partial class SavefilesAction : ButtonAction
{
    [Signal] public delegate void OpenSavefilesEventHandler();

    public override void Execute()
    {
        EmitSignal(SignalName.OpenSavefiles);
    }
}

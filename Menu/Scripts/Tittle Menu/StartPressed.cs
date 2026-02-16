using Godot;
using System;

public partial class StartPressed : Node
{
    [Signal] public delegate void StartingEventHandler();

    [Export] public Button _startButton;

    public override void _EnterTree()
    {
        _startButton.Pressed += () => EmitSignal(SignalName.Starting);
    }

}

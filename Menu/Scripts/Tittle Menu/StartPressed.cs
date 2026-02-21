using Godot;
using System;

public partial class StartPressed : Node
{
    [Signal] public delegate void StartingEventHandler();

    [Export] private Button _startButton;

    public override void _Ready()
    { 
        if (_startButton == null) return;

        _startButton.Disabled = false;

        _startButton.Pressed += OnButtonPressed;
    }

    private void OnButtonPressed()
    {
        _startButton.Disabled = true;
        EmitSignal(SignalName.Starting);
    }
}

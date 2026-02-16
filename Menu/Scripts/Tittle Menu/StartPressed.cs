using Godot;
using System;

public partial class StartPressed : Node
{
    [Signal] public delegate void StartingEventHandler();

    [Export] public Button _startButton;

    private AudioStreamPlayer _SFX;

    public override void _Ready()
    { 
        _startButton.Disabled = false;
        _SFX = GetParent().GetNode<AudioStreamPlayer>("EnterSFX");

        _startButton.Pressed += () => 
        {
            _SFX.Play();
            _startButton.Disabled = true;
            EmitSignal(SignalName.Starting);
        };
    }

}

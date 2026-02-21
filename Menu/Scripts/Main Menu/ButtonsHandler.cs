using Godot;
using System;

public partial class ButtonsHandler : Control
{
    [Export] private Label _label;
    [Export] private AudioStreamPlayer _click;
    [Export] private AudioStreamPlayer _hover;
    [Export] private AudioStreamPlayer _error;

    public override void _Ready()
    {
        foreach (var node in GetTree().GetNodesInGroup("MenuButtons"))
        {
            if (node is GenericUIAnimation button)
            {
                ButtonSetup(button);
            }
        }
    }

    private void ButtonSetup(GenericUIAnimation button)
    {
        button.MouseEntered += () => 
        {
            UpdateLabel(button.GetMeta("Description").AsString());
            _hover.Play();
            button.OnMouseEntered();
        };
                
        button.MouseExited += () => 
        {
            UpdateLabel(String.Empty);
            button.OnMouseExited();
        };

        button.Pressed += () => 
        {
            if (button.GetMeta("Disabled").AsBool())
            {
                _error.Play();
                return;
            }
            _click.Play();
            var action = button.GetNodeOrNull<ButtonAction>("Action");
            action.Execute();
        };
    }

    private void UpdateLabel(string text) => _label.Text = text;
}

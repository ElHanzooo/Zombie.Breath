using Godot;
using System;

public partial class ButtonsHandler : Control
{
    [Export] Label _label;

    public override void _Ready()
    {
        var buttons = GetTree().GetNodesInGroup("MenuButtons");
        foreach (var node in buttons)
        {
            if (node is GenericUIAnimation button)
            {
                button.MouseEntered += () => 
                {
                    UpdateLabel(button.GetMeta("Description").AsString());
                    button.OnMouseEntered();
                };
                
                button.MouseExited += () => 
                {
                    UpdateLabel(String.Empty);
                    button.OnMouseExited();
                };
            }
        }
    }

    private void UpdateLabel(string text)
    {
        _label.Text = text;
    }
}

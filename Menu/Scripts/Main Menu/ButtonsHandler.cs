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
            if (node is TextureButton button)
            {
                button.MouseEntered += () => UpdateLabel(button.GetMeta("Description").AsString());
                button.MouseExited += () => UpdateLabel(String.Empty);
            }
        }
    }

    private void UpdateLabel(string text)
    {
        _label.Text = text;
    }
}

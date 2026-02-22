using Godot;
using System;
//using System.Collections.Generic;
using Godot.Collections;

public partial class BackgroundHandler : Control
{
    [Export] private Control ShaderModulate;
    [Export] private Dictionary<string, Control> Backgrounds = new();

    public void UpdateBackground()
    {
        string currentTheme = GameManager.Instance.GetCurrentBackgroundName();

        foreach (var theme in Backgrounds.Keys)
        {
            if (theme == currentTheme)
            {
                Backgrounds[theme].Show();
            }
            else
            {
                Backgrounds[theme].Hide();
            }
        }

        if (ShaderModulate != null)
        {
            ShaderModulate.Modulate = GameManager.Instance.GetModulateColor();
        }
    }
}

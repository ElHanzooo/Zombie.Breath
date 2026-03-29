using Godot;
using System;
//using System.Collections.Generic;
using Godot.Collections;

public partial class BackgroundHandler : Control
{
    [Export] private Control ShaderModulate;
    [Export] private Dictionary<Episodes, Control> Backgrounds = new();

    public void UpdateBackground()
    {
        foreach (Episodes theme in Backgrounds.Keys)
        {
            if (theme == Global.Instance.Episode)
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
            ShaderModulate.Modulate = Global.Instance.Episode switch
            {
                Episodes.Day => new Color("ffffff"),
                Episodes.Afternoon => new Color("ffa569"),
                Episodes.Night => new Color("547aa1"),
                _ => ShaderModulate.Modulate
            };
        }
    }
}

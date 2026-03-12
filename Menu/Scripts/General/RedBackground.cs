using Godot;
using System;
using Godot.Collections;

public partial class RedBackground : Control
{
    [Export] Dictionary<Episodes, Color> Colors = new();

    public override void _Ready()
    {
        Modulate = Global.Episode switch
        {
            Episodes.Day => Colors.ContainsKey(Global.Episode) ? Colors[Global.Episode] : Modulate,
            Episodes.Afternoon => Colors.ContainsKey(Global.Episode) ? Colors[Global.Episode] : Modulate,
            Episodes.Night => Colors.ContainsKey(Global.Episode) ? Colors[Global.Episode] : Modulate,
            _ => Modulate
        };
    }
}

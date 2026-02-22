using Godot;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }

    public int CurrentAct { get; set; } = 1;
    public int CurrentEpisode { get; set; } = 1;

    public override void _Ready()
    {
        Instance = this;
    }

    public string GetCurrentBackgroundName()
    {
        if (CurrentEpisode == 1) return "Day";
        if (CurrentEpisode == 2) return "Afternoon";
        return "Night";
    }

    public Color GetModulateColor()
    {
        if (CurrentEpisode == 1) return new Color("ffffff"); // Day
        if (CurrentEpisode == 2) return new Color("ffa569"); // Afternoon
        return new Color("547aa1"); // Night
    }
}

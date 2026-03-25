using Godot;
using System;

public partial class Global : Node
{
    public static Global Instance { get; private set; }

    public int Act = 1;
    public Episodes Episode = Episodes.Day;

    public override void _Ready()
    {
        Instance = this;
    }

    public void PlaySFX(AudioStream sfx)
    {
        AudioStreamPlayer player = new()
        {
            Stream = sfx,
            Autoplay = true
        };
        AddChild(player);

        player.Finished += player.QueueFree;
    }
}

public enum Episodes
{
    Day,
    Afternoon,
    Night
}
using Godot;
using System;

public partial class MenuMusicPlayer : AudioStreamPlayer
{
    public static MenuMusicPlayer Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public void PlayMusic()
    {
        if (!Playing)
        {
            Play();
        }
    }

    public void StopMusic()
    {
        if (Playing)
        {
            Stop();
        }
    }
}

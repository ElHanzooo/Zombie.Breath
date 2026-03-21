using Godot;
using System;

[System.Serializable]
public class SaveData
{
    public int Act { get; set; } = 1;
    public Episodes Episode { get; set; } = Episodes.Day;
}

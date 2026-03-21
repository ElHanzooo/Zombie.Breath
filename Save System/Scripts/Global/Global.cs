using Godot;
using System;

public partial class Global : Node
{
    public static int Act { get; set; } = 1;
    public static Episodes Episode { get; set; } = Episodes.Day;
}

public enum Episodes
{
    Day,
    Afternoon,
    Night
}
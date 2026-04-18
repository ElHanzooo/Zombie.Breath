using Godot;
using System;

[GlobalClass]
public partial class StageConfig : Resource
{
    [Export] public Texture Thumbnail { get; set; }
    [Export] public int Act { get; set; } = 1;
    [Export] public Episodes Episode { get; set; }
}

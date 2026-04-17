using Godot;
using System;

[GlobalClass]
public partial class BGConfig : Resource
{
    [Export] public NodePath ControlBackgroundPath {get; set; }
    [Export] public Color ModulateColor {get ; set; }
}

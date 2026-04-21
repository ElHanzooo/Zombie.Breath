using Godot;
using System;

public abstract partial class Monster : Area2D
{
    [Export] public int Health { get; protected set; } = 50;
    [Export] public int AttackDamage { get; protected set; } = 30;
    [Export] public float Speed { get; protected set; } = 1;
}

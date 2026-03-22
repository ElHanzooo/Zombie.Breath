using Godot;
using System;
using System.Collections.Generic;

public partial class FiniteStateMachineComponent : Node
{
    private Dictionary<string, State> states = [];

    public override void _Ready()
    {
        foreach (var child in GetChildren())
            if (child is State state)
                states[state.Name.ToString().ToLower()] = state;
    }
}

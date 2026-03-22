using Godot;
using System;
using System.Collections.Generic;

public partial class FiniteStateMachineComponent : Node
{
    private State currentState;
    private Dictionary<string, State> states = [];

    public override void _Ready()
    {
        foreach (var child in GetChildren())
            if (child is State state)
            {
                states[state.Name.ToString().ToLower()] = state;
                state.Transitioned += OnStateTransition;
            }
    }

    public override void _Process(double delta)
    {
        currentState?.Update((float)delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        currentState?.PhysicsUpdate((float)delta);
    }

    private void OnStateTransition(string newStateName)
    {
        if (!states.TryGetValue(newStateName.ToLower(), out var newState))
            return;

        if (currentState == newState)
            return;

        currentState?.Exit();
        newState.Enter();
        currentState = newState;
    }
}

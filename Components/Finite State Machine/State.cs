using Godot;
using System;

[GlobalClass]
public partial class State : Node
{
    [Signal] public delegate void TransitionedEventHandler(string newStateName); // Sinal usado para trocar de estado.

    public virtual void Enter() { } // Ao entrar neste estado.
    public virtual void Exit() { } // Ao sair deste estado.
    public virtual void Update(double delta) { } // Atualização frame-a-frame.
    public virtual void PhysicsUpdate(double delta) { } // Atualização frame-a-frame com tick de física.
}

using Godot;
using System;

public abstract partial class State : Node
{
    [Signal]
    public delegate void TransitionToEventHandler(State self, string nextStateName);

    public CharacterBody2D actor;
    public MovementHandler movementHandler;
    protected State _previousState;
    // public virtual MovementHandler movementHandler { get; } = new MovementHandler();

    public virtual void Enter(State previousState)
    {
		// GD.Print($"Entered {GetType().Name}");
        _previousState = previousState;
    }
    public virtual void Exit()
    {
		// GD.Print($"Left {GetType().Name}");
    }
    public abstract void ProcessUpdate(double delta);
    public abstract void PhysicsUpdate(double delta);
}
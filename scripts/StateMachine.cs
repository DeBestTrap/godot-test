using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class StateMachine : Node
{
	[Export]
	private State _initialState;

	[Export]
	private MovementHandler _movementHandler;

	private Dictionary<string, State> _states;
	private State _previous;
	private State _current;

	public override void _Ready()
	{
		GD.Print($"\nInitial State: {_initialState.Name}, {_initialState}");
		_states = new Dictionary<string, State>();

		foreach (State state in GetChildren())
		{
			// Assign the actor of each state to be parent of the FSM.
			Node parent = GetParent();
			GD.Print($"parent type: {parent.GetType()}");
			state.actor = (CharacterBody2D)parent;
			state.movementHandler = _movementHandler;
			state.TransitionTo += ChildTransitionTo;
			_states.Add(state.Name, state);
		}
		GD.Print($"States:");
		foreach ((string str, State state) in _states)
		{
			GD.Print($"  {str}, {state}");
		}
		
		if (_initialState is not null)
		{
			_initialState.Enter(null);
			_current = _initialState;
		}
	}

	public void ForceTransitionTo(string nextStateName)
	{
		ChildTransitionTo(_current, nextStateName);
	}

	private void ChildTransitionTo(State state, string nextStateName)
	{
		if (_current != state)
		{
			return;
		}
		// GD.Print($"\nTransitioning from {state.Name} to {nextStateName}");

		State nextState = _states.GetValueOrDefault(nextStateName);
		if (nextState is null)
		{
			throw new Exception($"State {nextStateName} does not exist in the FSM tree.");
		}

		ChangeState(nextState);
	}


	public void ChangeState(State nextState)
	{
		if (_current is not null)
		{
			_previous = _current;
			_previous.Exit();
		}
		_current = nextState;
		_current.Enter(_previous);
	}

	public override void _Process(double delta)
	{
		if (_current is not null)
		{
			_current.ProcessUpdate(delta);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_current is not null)
		{
			_current.PhysicsUpdate(delta);
		}
	}

	// public override void _UnhandledInput(InputEvent @event)
	// {
	// 	// base._UnhandledInput(@event);
	// 	string next = current.HandleInput(@event);
	// 	GD.Print($"Transitioning to {next}");
	// 	State nextState = CheckStates(next);
	// 	ChangeState(nextState);
	// }

	private State CheckStates(string stateName)
	{
		// Checks the FSM's children to see if the state exists.
		//   If it does then return the state.
		//   Else throw an exception.
		foreach (State state in GetChildren())
		{
			if (stateName == state.Name)
			{
				return state;
			}
		}
		throw new Exception($"State {stateName} does not exist in FSM!");
	}
}

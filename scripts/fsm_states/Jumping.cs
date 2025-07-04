using Godot;
using System;

public partial class Jumping: State
{
	public override void ProcessUpdate(double delta) { }   

	public override void PhysicsUpdate(double delta)
	{
		// If the actor has reached the apex of their jump,
		//   then transition to the Falling state.
		if (actor.Velocity.Y >= 0)
		{
			EmitSignal(SignalName.TransitionTo, this, "Falling");
		}
	}
}

using Godot;
using System;

public partial class Idle : State
{
	public override void ProcessUpdate(double delta) { }   

	public override void PhysicsUpdate(double delta)
	{
		if (movementHandler.GetMovementDirection().X != 0)
		{
			EmitSignal(SignalName.TransitionTo, this, "Moving");
		}
	}
}

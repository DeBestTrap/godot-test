using Godot;

public partial class Grounded : State
{
	public override void ProcessUpdate(double delta) { }

	public override void PhysicsUpdate(double delta)
	{
		// If the actor has 
		if (movementHandler.WantsToJump())
		{
			EmitSignal(SignalName.TransitionTo, this, "Jump");
		}
		if (!actor.IsOnFloor())
		{
			EmitSignal(SignalName.TransitionTo, this, "Falling");
		}
	}
}
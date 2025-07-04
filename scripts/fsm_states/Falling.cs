using Godot;

public partial class Falling: State
{
    /*
    The Falling state adds extra gravity to the actor.
    */

    [Export]
    private float FallingMultiplier = 0.25f;

	public override void ProcessUpdate(double delta) { }   

	public override void PhysicsUpdate(double delta)
	{
        // Add additional gravity * the falling multipler
		actor.Velocity += FallingMultiplier * actor.GetGravity() * (float)delta;

        // If the actor has landed on the floor then transition to Grounded.
		if (actor.IsOnFloor())
        {
            EmitSignal(SignalName.TransitionTo, this, "Grounded");
        }
	}
}
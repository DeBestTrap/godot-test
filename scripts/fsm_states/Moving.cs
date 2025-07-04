using Godot;

public partial class Moving : State
{
	public override void ProcessUpdate(double delta) { }

	public override void PhysicsUpdate(double delta)
	{
		float Speed = 150.0f;
		float directionX = movementHandler.GetMovementDirection().X;
		float velocityX;
		if (directionX != 0)
		{
			velocityX = directionX * Speed;
		}
		else
		{
			velocityX = Mathf.MoveToward(actor.Velocity.X, 0, Speed);
		}

		if (velocityX == 0)
		{
			EmitSignal(SignalName.TransitionTo, this, "Idle");
		}
		actor.Velocity = new Vector2(velocityX, actor.Velocity.Y);
	}
}
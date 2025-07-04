using Godot;

public partial class PlayerFalling : Falling
{
	/*
	The Falling state adds extra gravity to the actor.
	*/

	[Export]
	private float FallingMultiplier = 0.25f;

	private Godot.Timer _coyoteTimer;

	private bool _canCoyoteJump = false;


	public override void _Ready()
	{
		_coyoteTimer = GetNode<Godot.Timer>("CoyoteTimer");
	}

	public override void Enter(State previousState)
	{
		base.Enter(previousState);

		// Actor can only coyote jump after leaving the ground.
		if (_previousState.Name == "Grounded")
		{
			_coyoteTimer.Start();
			_canCoyoteJump = true;
		}
	}

	public override void ProcessUpdate(double delta) { }

	public override void PhysicsUpdate(double delta)
	{
		// Checks for coyote jumps
		if (_canCoyoteJump && movementHandler.WantsToJump())
		{
			EmitSignal(SignalName.TransitionTo, this, "Jump");
		}

		base.PhysicsUpdate(delta);
	}

	private void OnCoyoteTimerTimeout()
	{
		_canCoyoteJump = false;
		_coyoteTimer.Stop();
	}
}

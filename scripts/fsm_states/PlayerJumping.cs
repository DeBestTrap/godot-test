using Godot;
using System;

public partial class PlayerJumping : Jumping 
{
	[Export]
	private float JumpCuttingMultiplier = 0.6f;
	private bool _cutApplied = false;

	public override void Enter(State previousState)
	{
		_cutApplied = false;
		base.Enter(previousState);
	}

	public override void ProcessUpdate(double delta) { }

	public override void PhysicsUpdate(double delta)
	{
		// Jump cutting when the actor "releases the key"
		//   so the cut is only applied once.
		if (!_cutApplied && !movementHandler.JumpHeld())
		{
			actor.Velocity *= new Vector2(1, JumpCuttingMultiplier);
			_cutApplied = true;
		}

		base.PhysicsUpdate(delta);
	}
}

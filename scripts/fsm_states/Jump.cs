using Godot;
using System;
using System.Threading.Tasks;

public partial class Jump : State
{
	[Export]
	public float JumpVelocity { get; set; } = -300.0f;

	public override void Enter(State previousState)
	{
		Vector2 _velocity = actor.Velocity;
		_velocity.Y = JumpVelocity;
		actor.Velocity = _velocity;
		base.Enter(previousState);
	}

	public override void ProcessUpdate(double delta) { }

	public override void PhysicsUpdate(double delta) { EmitSignal(SignalName.TransitionTo, this, "Jumping");
	}
}

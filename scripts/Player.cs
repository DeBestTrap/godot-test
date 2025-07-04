using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody2D
{
	private GameManager GM;
	
	public const float Speed = 150.0f;
	public const float JumpVelocity = -250.0f;
	public bool Dead = false;
	
	private Vector2 _velocity;
	private Vector2 _direction;
	private Godot.AnimatedSprite2D _animatedSprite;
	private bool _deathAnimationPlayed = false;
	private StateMachine _stateMachine;
	private PlayerMovementHandler _movementHandler;

	public override void _Ready()
	{
		// Engine.TimeScale = 0.25;
		GM = GetNode<GameManager>("/root/Root/GameManager");

		_animatedSprite = GetNode<Godot.AnimatedSprite2D>("AnimatedSprite2D");
		_movementHandler = GetNode<PlayerMovementHandler>("PlayerMovementHandler");
		_stateMachine = GetNode<StateMachine>("VerticalFSM");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Apply gravity.
		Velocity += GetGravity() * (float)delta;
		MoveAndSlide();
		AnimationHandler();
	}

	public void SetDeathFlag()
	{
		Dead = true;
	}
	
	private void AnimationHandler()
	{
		if (Dead)
		{
			if (!_deathAnimationPlayed)
			{
				_animatedSprite.Play("Dead");
				_deathAnimationPlayed = true;
			}
			return;
		}
		
		if (!IsOnFloor())
		{
			_animatedSprite.Play("Jump");
		}
		else
		{
			if (_direction == Vector2.Zero)
			{
				_animatedSprite.Play("Idle");
			}
			else if (Mathf.Abs(_direction.X) > 0.0f)
			{
				_animatedSprite.Play("Run");
			}
		}
		
		// Controlling the sprite based on the direction;
		if (_direction.X < 0)
		{
			_animatedSprite.FlipH = true;
		}
		else if (_direction.X > 0)
		{
			_animatedSprite.FlipH = false;
		}
	}
	

	private void ShowDebug()
	{
		String text = "";
		void BuildDebugText(
			//String name,
			Object obj,
			[CallerArgumentExpression("obj")] string objName = "")
		{
			text += $"{objName}: {obj}\n";
			//text += $"{name}: obj\n"
			
		}
		// float coyoteTimeLeft = MathF.Round((float)_coyoteTimer.TimeLeft, 2);
		// float jumpBufferTimeLeft = MathF.Round((float)_jumpBufferTimer.TimeLeft, 2);
		// BuildDebugText(_jumpBuffered);
		// BuildDebugText(jumpBufferTimeLeft);
		// BuildDebugText(_deathAnimationPlayed);
		// BuildDebugText(coyoteTimeLeft);
		// BuildDebugText(_canCoyoteJump);
		// GM.SetDebugText(text);
	}
}

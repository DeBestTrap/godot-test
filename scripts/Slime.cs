using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	public const double Speed = 25.0;
	
	private int Direction = 1;
	private Godot.RayCast2D _rayCastRight;
	private Godot.RayCast2D _rayCastLeft;
	private Godot.AnimatedSprite2D _animatedSprite;
	
	public override void _Ready()
	{
		_rayCastRight = GetNode<Godot.RayCast2D>("RayCastRight");
		_rayCastLeft = GetNode<Godot.RayCast2D>("RayCastLeft");
		_animatedSprite = GetNode<Godot.AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 position = Position;
		
		if (_rayCastRight.IsColliding()) {
			Direction = -1;
			_animatedSprite.FlipH = true;
		}
		else if (_rayCastLeft.IsColliding())
		{
			Direction = 1;
			_animatedSprite.FlipH = false;
		}
		
		position.X += (float)(Direction * Speed * delta);
		Position = position;
	}
}

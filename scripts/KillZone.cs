using Godot;
using System;

public partial class KillZone : Area2D
{	
	private Godot.Timer _timer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = GetNode<Godot.Timer>("Timer");
		//This acts like going to the `Node` tab and connecting the signal from there.
		//_timer.Timeout += this.OnTimerTimeout; 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnBodyEntered(Node2D body)
	{
		Health health = body.GetNode<Health>("Health");
		health.Damage(20);
		// GD.Print("Player died");
		// Engine.TimeScale = 0.5;
		// if (_timer.IsStopped())
		// {
		// 	_timer.Start();
		// 	GD.Print("Reset timer started!");
		// }
		
		// Player player = (Player)body;
		// player.SetDeathFlag();
	}
	
	private void OnTimerTimeout()
	{
		GD.Print("Reset timer timed out");
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}
}

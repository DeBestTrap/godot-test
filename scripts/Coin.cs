using Godot;
using System;

public partial class Coin : Area2D
{
	private GameManager GM;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GM = GetNode<GameManager>("/root/Root/GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnBodyEntered(Node2D body) {
		GM.AddOneScore();
		this.QueueFree();
	}
}

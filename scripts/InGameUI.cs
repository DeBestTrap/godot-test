using Godot;
using System;

public partial class InGameUI : Control
{
	private Godot.Label _health;
	private Godot.Label _score;
	private Godot.Label _debugText;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_health = GetNode<Godot.Label>("MarginContainer/StatsBox/Stats/StatsVContainer/Health");
		_score = GetNode<Godot.Label>("MarginContainer/StatsBox/Stats/StatsVContainer/Score");
		_debugText = GetNode<Godot.Label>("MarginContainer/DebugBox/DebugInfo/VBoxContainer/DebugText");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SetScore(int score)
	{
		_score.SetText("Score: " + score.ToString());
	}
	
	public void SetDebugText(String text)
	{
		_debugText.SetText(text);
	}
}

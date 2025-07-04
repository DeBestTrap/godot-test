using Godot;
using System;

public partial class GameManager : Node
{
	private int _score = 0;
	private int _health = 3;
	private InGameUI UI;
	private String DebugText;
	
	public override void _Ready()
	{
		UI = GetNode<InGameUI>("/root/Root/CanvasLayer/InGameUI");
		GD.Print(UI);
		_displayScore();
	}
	
	public void SetScore(int score)
	{
		_score = score;
		_displayScore();
	}
	
	public void AddOneScore()
	{
		_score += 1;
		_displayScore();
	}
	
	private void _displayScore()
	{
		UI.SetScore(_score);
		GD.Print($"Score: {_score}");
	}
	
	public void SetDebugText(String text)
	{
		UI.SetDebugText(text);
	}
}

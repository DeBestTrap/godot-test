using Godot;

public partial class PlayerMovementHandler : MovementHandler
{
    private CharacterBody2D _actor;
    private Godot.Timer _jumpBufferTimer;

    private bool _jumpBuffered = false;
    public override void _Ready()
    {
        _jumpBufferTimer = GetNode<Godot.Timer>("JumpBufferTimer");
        _actor = (CharacterBody2D)GetParent();
    }

    public override Vector2 GetMovementDirection()
    {
        return Input.GetVector("move_left", "move_right", "move_up", "move_down");
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("jump"))
        {
            _jumpBuffered = true;
            _jumpBufferTimer.Start();
        }
    }

    public override bool WantsToJump()
    {
        if (_jumpBuffered)
        {
            return true;
        }

        return Input.IsActionJustPressed("jump");
    }

    public override bool JumpHeld()
    {
        return Input.IsActionPressed("jump");
    }

    private void OnJumpBufferTimerTimeout()
	{
		_jumpBuffered = false;
		_jumpBufferTimer.Stop();
	}
	
}
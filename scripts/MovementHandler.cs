using Godot;
using System;

public partial class MovementHandler : Node
{
    public virtual Vector2 GetMovementDirection()
    {
        return Vector2.Zero;
    }

    public virtual bool WantsToJump()
    {
        return false;
    }

    public virtual bool JumpHeld()
    {
        return false;
    }
}
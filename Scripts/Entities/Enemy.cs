using Godot;
using System;

public class Enemy : Entity
{
    public override void _Ready()
    {
    }

    [Export] float jumpReactionTime = 0.3f; //time between need for jump and jump
    [Export] float stopDistance = 10; //distance at which he stops pursuing
    [Export] float fixYDistance = 10; //Doesn't need to jump if the height difference is below this
    [Export] float tanJumpAngle = 1.4f; // tangent of the angle below which he doesn't jump 

    // Gather data on player
    Vector2 getPlayerPostion => Perso.Instance.Position;
    bool canSeePlayer => (Position - getPlayerPostion).Length() < float.MaxValue;

    // Private data
    bool jumpInitiated = false;

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        base._IntegrateForces(state);

        bool right = false;
        bool left = false;
        bool jump = false;
        if (canSeePlayer)
        { // Pursuit behavior
            float xDist = getPlayerPostion.x - Position.x;
            float yDist = getPlayerPostion.y - Position.y;
            if ((Position - getPlayerPostion).Length() > stopDistance)
            {
                if (xDist > stopDistance)
                    right = true;
                else if (xDist < -stopDistance)
                    left = true;
            }
            if (IsGrounded)
            {
                if (yDist < -fixYDistance && -yDist > Math.Abs(xDist * tanJumpAngle) && !jumpInitiated)
                {
                    jumpInitiated = true;
                    TimerFactory.MakeTimer(this, jumpReactionTime, () => { Jump(); jumpInitiated = false; });
                }
            }
        }

        Move(right, left, jump);
    }
}

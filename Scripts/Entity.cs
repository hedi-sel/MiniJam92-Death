using Godot;
using System;

public class Entity : RigidBody2D
{
    [Export] private float hSpeed = 100;
    [Export] private float jumpForce = 100;

    public bool IsGrounded { get; protected set; } = false;
    public bool IsLookingLeft { get; protected set; } = false;

    protected void Jump()
    {
        if (!IsGrounded)
            return;
        ApplyCentralImpulse(Vector2.Up * jumpForce);
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        IsGrounded = state.GetContactCount() > 0 && state.GetContactColliderPosition(0).y > GlobalPosition.y;
    }

    public void Move(bool right, bool left, bool jump)
    {
        UpdateIsLookingLeft(right, left);
        var velocity = LinearVelocity;
        velocity.x = hSpeed * ((right && !left) ? 1 : (left && !right) ? -1 : 0);
        LinearVelocity = velocity;
        if (jump)
            Jump();
    }

    private void UpdateIsLookingLeft(bool right, bool left)
    {
        if (left || right)
            IsLookingLeft = left && !right;
    }
}
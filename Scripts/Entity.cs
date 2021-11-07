using Godot;
using System;

public class Entity : RigidBody2D
{
    [Export] private float hSpeed = 100;
    [Export] private float jumpForce = 1000;

    public bool IsGrounded { get; protected set; } = false;

    public override void _Ready()
    {
    }

    protected void Jump()
    {
        ApplyCentralImpulse(Vector2.Up * jumpForce);
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        IsGrounded = state.GetContactCount() > 0 && state.GetContactColliderPosition(0).y > GlobalPosition.y;
    }

    public void Move(bool right, bool left, bool jump)
    {
        LinearVelocity = hSpeed * ((right && !left) ? Vector2.Right : (left && !right) ? Vector2.Left : Vector2.Zero);
        if (jump)
            Jump();
    }

}
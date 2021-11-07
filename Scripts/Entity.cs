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
        var velocity = LinearVelocity;
        velocity.x = hSpeed * ((right && !left) ? 1 : (left && !right) ? -1 : 0);
        LinearVelocity = velocity;
        if (jump)
            Jump();
    }

}
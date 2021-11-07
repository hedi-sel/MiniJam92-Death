using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public class Entity : RigidBody2D {
    [Export] private float hSpeed = 100;
    [Export] private float jumpForce = 100;

    public bool IsGrounded { get; protected set; } = false;
    public bool IsLookingLeft { get; protected set; } = false;

    protected void Jump () {
        if (!IsGrounded)
            return;
        ApplyCentralImpulse(Vector2.Up * jumpForce);
    }

    IEnumerable<CollisionObject2D> GetContacts () {
        foreach (var body in GetCollidingBodies()) {
            yield return (CollisionObject2D) body;
        }
    }

    public override void _IntegrateForces (Physics2DDirectBodyState state) {
        IsGrounded = GetContacts().Where(node => node.GetCollisionLayerBit(1)).Any();
    }

    public void Move (bool right, bool left, bool jump) {
        UpdateIsLookingLeft(right, left);
        var velocity = LinearVelocity;
        velocity.x = hSpeed * ((right && !left) ? 1 : (left && !right) ? -1 : 0);
        LinearVelocity = velocity;
        if (jump)
            Jump();
    }

    private void UpdateIsLookingLeft (bool right, bool left) {
        if (left || right)
            IsLookingLeft = left && !right;
    }
}
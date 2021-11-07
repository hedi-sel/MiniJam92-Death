using Godot;
using System;

public class Perso : Entity
{
    public static Perso Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        base._IntegrateForces(state);
        
        var left = Input.IsActionPressed("ui_left");
        var right = Input.IsActionPressed("ui_right");
        var jump = Input.IsActionPressed("jump");
        
        Move(right, left, jump);
    }
}

using Godot;
using System;

public class Perso : RigidBody2D
{
    [Export] private int speed = 50;
    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_left"))
            Position += new Vector2(delta * speed,0);
    }
}

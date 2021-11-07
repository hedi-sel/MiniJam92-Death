using Godot;
using System;

public class Perso : Entity
{
    public static Perso Instance { get; private set; }

    [Export] private int speed = 50;

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_left"))
            Position += new Vector2(delta * speed, 0);
    }
}

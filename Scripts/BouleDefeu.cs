using Godot;
using System;

public class BouleDefeu : Node2D
{
    [Export] public float speed = 100;
    public override void _Process(float delta)
    {
      Position += new Vector2(delta * speed, 0);
    }
}

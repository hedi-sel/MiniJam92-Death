using Godot;
using System;

public class BouleDefeu : Node2D
{
    [Export] public float speed = 100;
    public bool IsLeftOriented = false;
    private static int instanceCount;

    public BouleDefeu()
    {
        instanceCount++;
    }
    public override void _Process(float delta)
    {
        Position += new Vector2((IsLeftOriented ? -1 : 1) * delta * speed, 0);
    }
}

using System;
using Godot;

public class FireballLayer : Node2D
{
    public static FireballLayer instance;
    public override void _Ready()
    {
        instance = this;
    }
}
using System;
using Godot;

public class Fireball_layer : Node2D
{
    public static Fireball_layer instance;
    public override void _Ready()
    {
        instance = this;
    }
}
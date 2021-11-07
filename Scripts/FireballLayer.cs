using System;
using Godot;

public class FireballLayer : Node2D {
    public static FireballLayer Instance { get; private set; }

    public override void _Ready () {
        Instance = this;
    }
}
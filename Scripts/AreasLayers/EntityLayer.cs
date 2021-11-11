using System;
using Godot;

public class EntityLayer : Node2D {
    public static EntityLayer Instance { get; private set; }

    public override void _Ready () {
        Instance = this;
    }
}

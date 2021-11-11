using System;
using Godot;

public class ProjectileTracker : Area2D {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready () {
        Connect("area_exited", this, nameof(OnAreaExited));
    }

    public void OnAreaExited (Area2D area) {
        area.QueueFree();
    }
}

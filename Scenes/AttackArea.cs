using System;
using Godot;

public class AttackArea : Area2D {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready () {
        Connect("body_entered", this, nameof(OnBodyEntered));
    }


    void OnBodyEntered (Node body) {
        ((Perso) body).Hit();
    }
}

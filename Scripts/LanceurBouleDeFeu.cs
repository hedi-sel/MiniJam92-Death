using System;
using Godot;

public class LanceurBouleDeFeu : Node2D
{
    [Export] public PackedScene PackedBouleDeFeu;

    public void LancerBouleDeFeu()
    {
        Node2D fireball = (Node2D)PackedBouleDeFeu.Instance();
        FireballLayer.instance.AddChild(fireball);
        fireball.GlobalPosition = this.GlobalPosition;

    }
}
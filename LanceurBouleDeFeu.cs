using System;
using Godot;

public class LanceurBouleDeFeu : Node2D
{
    [Export] public PackedScene PackedBouleDeFeu;

    public void LancerBouleDeFeu()
    {
        Node2D instance = (Node2D)PackedBouleDeFeu.Instance();
        Fireball_layer.instance.AddChild(instance);
        instance.GlobalPosition = this.GlobalPosition;
    }
}
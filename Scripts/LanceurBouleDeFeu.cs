using System;
using Godot;

public class LanceurBouleDeFeu : Node2D {
    [Export] public PackedScene PackedBouleDeFeu;

    bool CanAttack () => GetParent<Perso>().CurrentState != Perso.State.attack;

    private void LancerBouleDeFeu () {
        Node2D fireball = (Node2D) PackedBouleDeFeu.Instance();
        FireballLayer.Instance.AddChild(fireball);
        fireball.GlobalPosition = this.GlobalPosition;
    }

    public override void _Input (InputEvent @event) {
        if (@event.IsActionPressed("throw_fireball"))
            LancerBouleDeFeu();
    }
}
using System;
using Godot;

public class LanceurBouleDeFeu : Node2D {
    [Export] public PackedScene PackedBouleDeFeu;
    private Entity _entity;
    private bool isLeftOriented;

    public override void _Ready()
    {
        _entity = GetParent<Entity>();
        _entity.DirectionChanged += UpdatePositionAndDirection;
        isLeftOriented = _entity.IsLookingLeft;
    }

    private void UpdatePositionAndDirection(bool orientation)
    {
        Position *= new Vector2(-1,0);
        isLeftOriented = orientation;
    }

    bool CanAttack () => GetParent<Perso>().CurrentState != Perso.State.attack;

    private void LancerBouleDeFeu () {
        var fireball = (BouleDefeu)PackedBouleDeFeu.Instance();
        FireballLayer.Instance.AddChild(fireball);
        fireball.IsLeftOriented = isLeftOriented;
        fireball.GlobalPosition = this.GlobalPosition;
    }

    public override void _Input (InputEvent @event) {
        if (@event.IsActionPressed("throw_fireball"))
            LancerBouleDeFeu();
    }
}
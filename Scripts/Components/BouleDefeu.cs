using System;
using Godot;

public class BouleDefeu : Area2D {

    private static int instanceCount;
    public BouleDefeu () {
        instanceCount++;
    }

    [Export] public float Speed = 1000;

    Vector2 SpeedVector;
    bool directionSet = false;

    private bool _isLeftOriented = false;
    public bool IsLeftOriented {
        get { return _isLeftOriented; }
        set {
            if (directionSet)
                throw new Exception("Direction of BouleDeFeu already set");
            _isLeftOriented = value;
        }
    }

    public override void _Ready () {
        base._Ready();
        directionSet = true;
        GetNode<Sprite>("Sprite").FlipH = !IsLeftOriented;
        SpeedVector = new Vector2((IsLeftOriented ? -1 : 1) * Speed, 0);

        Connect("body_entered", this, nameof(OnBodyEntered));
    }

    public override void _Process (float delta) {
        Position += SpeedVector * delta;
    }

    public void OnBodyEntered (Node body) {
        Entity entity = (Entity) body;
        if (entity is Perso) return;
        entity.Die(GlobalPosition);
    }
}

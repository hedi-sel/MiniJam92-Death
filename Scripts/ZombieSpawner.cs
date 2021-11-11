using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Utils;

public class ZombieSpawner : RandomPosition2D {
    static ZombieSpawner _chiefSpawner = null;
    static List<ZombieSpawner> _spawnerList = new List<ZombieSpawner>();

    [Export] PackedScene PackedZombie;

    float _spawnCooldwon = 1.0f;
    bool _enabled = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready () {
        base._Ready();
        Connect("body_entered", this, nameof(OnBodyEntered));
        Connect("body_exited", this, nameof(OnBodyExited));

        _spawnerList.Add(this);
        if (_chiefSpawner == null) {
            _chiefSpawner = this;
            TimerFactory.MakeTimer(this, _spawnCooldwon, () => SpawnOne(), true);
        }
    }

    void SpawnOne () {
        var chosenSpawner = _spawnerList.Where(spawner => spawner._enabled).Random();
        var position = chosenSpawner.GetRandomGlobalPosition();
        GD.Print(chosenSpawner.GlobalPosition + "  " + position);
        var zombie = (Entity) chosenSpawner.PackedZombie.Instance();
        EntityLayer.Instance.AddChild(zombie);
        zombie.GlobalPosition = position;
    }

    void OnBodyEntered (Node body) {
        GD.Print("Enter" + this);
        _enabled = false;
    }
    void OnBodyExited (Node body) {
        GD.Print("Exit" + this);
        _enabled = true;
    }
    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

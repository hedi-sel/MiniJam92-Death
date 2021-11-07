using System;
using Godot;

public class Perso : Entity {
    public static Perso Instance { get; private set; }

    EntitySprite animatedSprite;
    public override void _Ready () {
        Instance = this;

        animatedSprite = GetNode<EntitySprite>("Sprite");
    }

    public enum State { walk, idle, attack }

    State currentState;
    public State CurrentState {
        get => currentState;
        private set {
            if (value == currentState) return;
            if (currentState == State.attack) return;
            else {
                currentState = value;
                if (currentState == State.attack) {
                    animatedSprite.PlayOnce(State.attack.ToString(), State.idle.ToString());
                    Callback.Connect(animatedSprite, "animation_finished", () => currentState = State.idle);
                } else
                    animatedSprite.Play(currentState.ToString());
            }
        }
    }

    void SetState (State state) {
    }

    public override void _IntegrateForces (Physics2DDirectBodyState state) {
        base._IntegrateForces(state);

        var left = Input.IsActionPressed("ui_left");
        var right = Input.IsActionPressed("ui_right");
        var jump = Input.IsActionPressed("jump");

        Move(right, left, jump);

        if (LinearVelocity.x != 0)
            CurrentState = State.walk;
        else
            CurrentState = State.idle;


    }
}

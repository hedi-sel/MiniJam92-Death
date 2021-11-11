using System;
using Godot;

public class BloodSack : TextureProgress {
    [Export] float minValue = 60;
    [Export] float maxValue = 73;

    public void SetBlood (float value) {
        Value = 60 + (73 - 60) * value;
    }

    private Perso _perso;
    public override void _Ready () {
        originalPosition = RectPosition;
        SetBlood(1f);

        _perso = GetParent<Perso>();
        _perso.UpdateHp += SetBlood;
        _perso.DirectionChanged += UpdateSpriteOrientation;
    }

    Vector2 originalPosition;
    private void UpdateSpriteOrientation (bool direction) {
        if (direction) {
            RectScale = new Vector2(-1, 1);
            RectPosition = originalPosition + new Vector2(RectSize.x, 0);
        } else {
            RectScale = new Vector2(1, 1);
            RectPosition = originalPosition;
        }
    }
}

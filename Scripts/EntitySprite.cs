using System;
using Godot;

public class EntitySprite : SmartAnimatedSprite {
    public override void _Ready () {
        UpdateSpriteOrientation();
    }

    public override void _Process (float delta) {
        UpdateSpriteOrientation();
    }

    private void UpdateSpriteOrientation () {
        FlipH = GetParent<Entity>().IsLookingLeft;
    }
}

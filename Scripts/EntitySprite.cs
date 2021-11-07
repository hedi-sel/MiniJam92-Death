using Godot;
using System;

public class EntitySprite : AnimatedSprite
{
    public override void _Ready()
    {
        UpdateSpriteOrientation();
    }

    public override void _Process(float delta)
    {
        UpdateSpriteOrientation();
    }
    
    private void UpdateSpriteOrientation()
    {
        FlipH = GetParent<Entity>().IsLookingLeft;
    }
}

using System;
using Godot;

public class EntitySprite : SmartAnimatedSprite 
{
    private Entity _entity;
    public override void _Ready () 
    {
        _entity = GetParent<Entity>();
        _entity.DirectionChanged += UpdateSpriteOrientation;
    }

    private void UpdateSpriteOrientation(bool direction)
    {
        FlipH = direction;
    }
}

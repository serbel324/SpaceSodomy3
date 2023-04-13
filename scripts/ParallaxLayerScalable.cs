using Godot;
using System;

public partial class ParallaxLayerScalable : ParallaxLayer
{
    [Export]
    public float backgroundScale;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Sprite2D sprite = GetNode("Sprite2D") as Sprite2D;
        float textureSize = sprite.Texture.GetSize().X;
        Vector2 screenSize = GetViewport().GetVisibleRect().Size;
        float scaleX = backgroundScale * screenSize.X/textureSize;
        sprite.Scale = new Vector2(scaleX, scaleX);
        MotionMirroring = new Vector2(textureSize*scaleX, textureSize*scaleX);
    }
}

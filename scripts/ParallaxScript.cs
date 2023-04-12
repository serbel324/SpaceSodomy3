using Godot;
using System;

public partial class ParallaxScript : Sprite2D
{
    [Export]
    public float parallaxCoefficient;
    [Export]
    public float backgroundScale;

    private Camera2D _mainCamera;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _mainCamera = GetViewport().GetCamera2D();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Vector2 screenSize = GetViewport().GetVisibleRect().Size;
        float ScaleX = backgroundScale * screenSize.X/Texture.GetSize().X;
        float cameraZoom = _mainCamera.Zoom.X;
        Scale = new Vector2(ScaleX, ScaleX)/cameraZoom;
        Position = _mainCamera.GlobalPosition * parallaxCoefficient;
        
    }
}

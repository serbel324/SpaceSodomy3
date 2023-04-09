using Godot;
using System;

public partial class ParallaxScript : Node2D
{
    [Export]
    public float parallaxCoefficient;

    private Camera2D _mainCamera;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _mainCamera = GetViewport().GetCamera2D();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position = _mainCamera.GlobalPosition * parallaxCoefficient;
    }
}

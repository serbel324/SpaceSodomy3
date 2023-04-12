using Godot;
using System;

public partial class CameraScript : Camera2D
{
    [Export]
    public Node2D objectToFollow;

    [Export]
    public float mouseShift;

    [Export]
    public float minZoom;

    [Export]
    public float maxZoom;

    [Export]
    public float zoomStep;

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            InputEventMouseButton emb = (InputEventMouseButton)@event;
            if (emb.IsPressed())
            {
                float oldZoom = Zoom.Length() / Mathf.Sqrt(2);
                float newZoom = oldZoom;
                if (emb.ButtonIndex == MouseButton.WheelUp)
                {
                    newZoom = Mathf.Max(oldZoom / zoomStep, minZoom);
                } else if (emb.ButtonIndex == MouseButton.WheelDown)
                {
                    newZoom = Mathf.Min(oldZoom * zoomStep, maxZoom);
                }
                Zoom = new Vector2(newZoom, newZoom);
            }
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
        Vector2 mousePosition = GetViewport().GetMousePosition();
        Vector2 screenSize = GetViewport().GetVisibleRect().Size;
        Vector2 deltaPosition = (mousePosition - screenSize / 2) / GetViewport().GetCamera2D().Zoom * mouseShift;
        Position = objectToFollow.Position + deltaPosition;
    }
}

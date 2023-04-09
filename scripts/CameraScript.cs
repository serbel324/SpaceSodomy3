using Godot;
using System;

public partial class CameraScript : Camera2D
{
    [Export]
    public Node objectToFollow;

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

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        /* TODO
        Vector2 mousePosition = GetViewport().GetMousePosition();
        float mouseX = (mousePosition - Screen.width / 2) / Screen.width;
        float mouseY = (mousePosition - Screen.height / 2) / Screen.height;
        cam.transform.position = new Vector3(
            objectToFollow.transform.position.x + mouseX * mouseShift,
            objectToFollow.transform.position.y + mouseY * mouseShift,
            cam.transform.position.z
        );
        */
    }
}

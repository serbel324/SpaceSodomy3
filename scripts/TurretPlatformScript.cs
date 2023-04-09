using Godot;
using System;

public partial class TurretPlatformScript : Node2D
{
    private Node2D _turret;

    [Export]
    public float maxRotationAngle;

    [Export]
    public float rotationSpeed;

    [Export]
    public float aimedInterval;

    private bool _isAimed;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _turret = GetParent() as Node2D;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    public bool IsAimed()
    {
        return _isAimed;
    }

    // Update is called once per frame
    public void AimOnScreenPoint(Vector2 screenPoint, double deltaTime)
    {
        Vector2 direction = GlobalTransform.X;
        Vector2 deltaMouse = screenPoint - GetGlobalTransformWithCanvas().Origin;
        float deltaMouseAngle = VectorRotations.AngleBetweenVectors(direction, deltaMouse);

        float deltaRotation = 0;
        if (deltaMouseAngle > Mathf.Epsilon)
        {
            deltaRotation = Mathf.Min(rotationSpeed * (float)deltaTime, deltaMouseAngle);
        } else if (deltaMouseAngle < -Mathf.Epsilon)
        {
            deltaRotation = Mathf.Max(-rotationSpeed * (float)deltaTime, deltaMouseAngle);
        }
        _isAimed = Mathf.Abs(deltaMouseAngle) < aimedInterval;

        RotationDegrees += deltaRotation;
        RotationDegrees = Mathf.Min(RotationDegrees, maxRotationAngle);
        RotationDegrees = Mathf.Max(RotationDegrees, -maxRotationAngle);
    }
}

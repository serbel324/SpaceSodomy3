using Godot;
using System;

public partial class TurretScript : Node
{
    [Export]
    public PackedScene gunScene;

    private BaseGun _gun;
    private TurretPlatformScript _platform;
    private RigidBody2D _carrier;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _platform = GetNode("Platform") as TurretPlatformScript;
        _carrier = GetParent().GetParent() as RigidBody2D;
        Node newInstance = gunScene.Instantiate();
        _platform.AddChild(newInstance);
        _gun = (BaseGun)newInstance;
        _gun.SetGunCarrier(_carrier);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void Fire()
    {
        if (_platform.IsAimed())
        {
            _gun.Fire();
        }
    }

    public void AimOnScreenPoint(Vector2 screenPoint, double deltaTime)
    {
        _platform.AimOnScreenPoint(screenPoint, deltaTime);
    }
}

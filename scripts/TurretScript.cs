using Godot;
using System;

public partial class TurretScript : Node
{
    private BaseGun _gun;
    private TurretPlatformScript _platform;
    private RigidBody2D _carrier;

    private bool _active;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _active = false;

        _platform = GetNode("Platform") as TurretPlatformScript;
        _carrier = GetParent().GetParent().GetParent() as RigidBody2D;

        WeaponController weaponController = GetParent().GetParent() as WeaponController;
        PackedScene gunScene = weaponController.GetTurretGunType();
        Node newInstance = gunScene.Instantiate();
        _platform.AddChild(newInstance);
        _gun = newInstance as BaseGun;
        _gun.SetGunCarrier(_carrier);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (_active)
        {
            Fire();
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void SetActive(bool active)
    {
        _active = active;
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

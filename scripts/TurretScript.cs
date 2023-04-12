using Godot;
using System;

public partial class TurretScript : ActiveModule
{
    private BaseGun _gun;
    private TurretPlatformScript _platform;
    private RigidBody2D _carrier;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
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
        _gun.SetActive(_isActive && _platform.IsAimed());
    }

    public void AimOnScreenPoint(Vector2 screenPoint, double deltaTime)
    {
        _platform.AimOnScreenPoint(screenPoint, deltaTime);
    }
}

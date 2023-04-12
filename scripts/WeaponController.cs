using Godot;
using System;

public partial class WeaponController : Node
{
    [Export]
    public PackedScene turretGunType;

    public PackedScene GetTurretGunType()
    {
        return turretGunType;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}

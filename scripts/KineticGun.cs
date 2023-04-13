using Godot;
using System;

public abstract partial class KineticGun : BaseGun
{
    [Export]
    public float reloadDuration;
    
    [Export]
    public float bulletSpawnForwardShift;
    
    [Export]
    public float angleDispersion;

    [Export]
    public PackedScene projectileScene;

    [Export]
    public float recoilImpulseMagnitude;

    private RandomNumberGenerator _random;
 
    protected float _reload;

    protected void _SpawnProjectile(Vector2 positionShift, float rotationShift)
    {
        RigidBody2D newProj = projectileScene.Instantiate() as RigidBody2D;
        newProj.GlobalRotationDegrees = GlobalRotationDegrees + _random.RandfRange(-angleDispersion, angleDispersion) + rotationShift;
        newProj.GlobalPosition = GlobalPosition + GlobalTransform.X * bulletSpawnForwardShift + positionShift;
        newProj.LinearVelocity += _gunCarrier.LinearVelocity;
        GetNode("/root").AddChild(newProj);
    
        _gunCarrier.ApplyCentralImpulse(GlobalTransform.X * -recoilImpulseMagnitude);
    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _random = new RandomNumberGenerator();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _reload = (float)Mathf.Max(0d, _reload - delta);

        if (_isActive && _reload == 0)
        {
            Fire();
        }
    }
}

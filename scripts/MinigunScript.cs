using Godot;
using System;

public partial class MinigunScript : BaseGun
{
    [Export]
    public float reloadDuration;
    
    [Export]
    public float distanceBetweenBarrels;
    
    [Export]
    public float bulletSpawnForwardShift;
    
    [Export]
    public float dispersion;

    [Export]
    public PackedScene projectileScene;

    // TODO: add shot sounds
    // public GameObject soundManager;
    // private MinigunSoundManagerScript soundManagerScript;

    [Export]
    public float recoilImpulseMagnitude;

    private int _barrel; // { -1, 1 }
 
    private float _reload;

    private RandomNumberGenerator _random;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _reload = 0;
        _barrel = 1;
        _random = new RandomNumberGenerator();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _reload = (float)Mathf.Max(0d, _reload - delta);
    }

    private void _SpawnProjectile()
    {
        Vector2 pos = GlobalPosition + GlobalTransform.Y * distanceBetweenBarrels / 2 * _barrel;
        pos += GlobalTransform.X * bulletSpawnForwardShift;
        float angleDeviation = _random.RandfRange(-dispersion, dispersion);

        RigidBody2D newProj = projectileScene.Instantiate() as RigidBody2D;
        newProj.GlobalRotationDegrees = GlobalRotationDegrees + angleDeviation;
        newProj.GlobalPosition = pos;
        newProj.LinearVelocity += _gunCarrier.LinearVelocity;
        GetNode("/root").AddChild(newProj);
    }

    public override void Fire()
    {
        if (_reload == 0)
        {
            _reload = reloadDuration;
            _SpawnProjectile();
            _gunCarrier.ApplyCentralImpulse(GlobalTransform.X * -recoilImpulseMagnitude);

            _barrel *= -1;
        }
    }


}

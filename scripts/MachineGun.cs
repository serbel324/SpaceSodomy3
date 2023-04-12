using Godot;
using System;

public partial class MachineGun : KineticGun
{
    [Export]
    public float distanceBetweenBarrels;

    private int _barrel; // { -1, 1 }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        _barrel = 1;
    }

    public override void Fire()
    {
        if (_reload == 0)
        {
            _reload = reloadDuration;
            _SpawnProjectile(GlobalTransform.Y * distanceBetweenBarrels / 2 * _barrel, 0);
            _gunCarrier.ApplyCentralImpulse(GlobalTransform.X * -recoilImpulseMagnitude);

            _barrel *= -1;
        }
    }


}

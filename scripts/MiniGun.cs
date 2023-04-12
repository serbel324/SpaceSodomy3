using Godot;
using System;

public partial class MiniGun : KineticGun
{
    [Export]
    public float chargeDuration;

    private float _chargeTime;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        _chargeTime = chargeDuration;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (IsActive())
        {
            _chargeTime = Mathf.Max(0, _chargeTime - (float)delta);
        } else
        {
            _chargeTime = chargeDuration;
        }

        base._Process(delta);
    }

    public override void Fire()
    {
        if (_chargeTime == 0 && _reload == 0)
        {
            _reload = reloadDuration;
            _SpawnProjectile(new Vector2(0, 0), 0);
        }
    }


}

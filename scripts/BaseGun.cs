using Godot;
using System;

public abstract partial class BaseGun : ActiveModule
{
    protected RigidBody2D _gunCarrier;

    public void SetGunCarrier(RigidBody2D gunCarrier)
    {
        _gunCarrier = gunCarrier;
    }

    public abstract void Fire();
}

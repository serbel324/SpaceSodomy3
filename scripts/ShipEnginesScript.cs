using Godot;
using System;

public partial class ShipEnginesScript : Node
{
    private RigidBody2D _rb;

    [Export]
    public float mainEnginePower;
    [Export]
    public float reverseEnginePower;
    [Export]
    public float rotaryEnginePower;
    [Export]
    public float sideEnginePower;
    [Export]
    public float brakePower;

    public override void _Ready()
    {    
        _rb = GetParent() as RigidBody2D;
    }

    public override void _Process(double delta)
    {
    }

    public void MainEngine()
    {
        _rb.ApplyForce(_rb.Transform.X * mainEnginePower);
    }

    public void ReverseEngine()
    {
        _rb.ApplyForce(_rb.Transform.X * -reverseEnginePower);
    }

    public void LeftSideEngine()
    {
        _rb.ApplyForce(_rb.Transform.Y * -sideEnginePower);
    }

    public void RightSideEngine()
    {
        _rb.ApplyForce(_rb.Transform.Y * sideEnginePower);
    }

    public void LeftRotaryEngine()
    {
        _rb.ApplyTorque(-rotaryEnginePower);
    }

    public void RightRotaryEngine()
    {
        _rb.ApplyTorque(rotaryEnginePower);
    }

    public void Brake()
    {
        Vector2 velocity = _rb.LinearVelocity;
        float angularVelocity = _rb.AngularVelocity;

        if (!velocity.IsZeroApprox())
        {
            _rb.ApplyForce(velocity.Normalized() * -brakePower);
        }
        else
        {
            _rb.LinearVelocity = new Vector2(0, 0);
        }

        if (!Mathf.IsZeroApprox(angularVelocity))
        {
            _rb.ApplyTorque(Mathf.Sign(angularVelocity) * -rotaryEnginePower);
        }
        else
        {
            _rb.AngularVelocity = 0;
        }
    }
}

using Godot;
using System;

public partial class BulletScript : RigidBody2D
{
    [Export]
    public float startingSpeed;

    [Export]
    public double timeToLive;

    [Export]
    public AudioStream shotSound;

    public AudioStreamPlayer2D _shotStreamPlayer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Vector2 initialImpulse = Transform.X * startingSpeed;
        LinearVelocity += initialImpulse;
        _shotStreamPlayer = new AudioStreamPlayer2D();
        _shotStreamPlayer.GlobalPosition = GlobalPosition;
        _shotStreamPlayer.Stream = shotSound;
        GetNode("/root").AddChild(_shotStreamPlayer);
        _shotStreamPlayer.Play();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        timeToLive -= delta;
        if (timeToLive <= 0)
        {
            _shotStreamPlayer.QueueFree();
            QueueFree();
        }
    }
}

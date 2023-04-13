using Godot;
using System;

public partial class Module : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}

public partial class ActiveModule : Module
{
    protected bool _isActive;

    public void SetActive(bool active)
    {
        _isActive = active;
    }

    public bool IsActive()
    {
        return _isActive;
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

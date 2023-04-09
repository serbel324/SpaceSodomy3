using Godot;
using System;
using System.Collections.Generic;

public partial class ShipControl : Node
{
    private Node _engines;
    private Node _turretsNode;
    private List<TurretScript> _turrets;
   // private List<TurretScript> _turretScripts;

    [Export]
    public Key mainEngineKey = Key.W;
    [Export]
    public Key reverseEngineKey = Key.S;
    [Export]
    public Key leftRotaryEngineKey = Key.A;
    [Export]
    public Key rightRotaryEngineKey = Key.D;
    [Export]
    public Key leftSideEngineKey = Key.Q;
    [Export]
    public Key rightSideEngineKey = Key.E;
    [Export]
    public Key brakeKey = Key.F;

    [Export]
    public Key fireKey = Key.Space;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _engines = GetNode("../Engines");
        _turretsNode = GetNode("../Turrets");
        _turrets = new List<TurretScript>();
        foreach (Node turret in _turretsNode.GetChildren())
        {
            _turrets.Add((TurretScript)turret);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsKeyPressed(mainEngineKey))
        {
            _engines.Call("MainEngine");
        }
        if (Input.IsKeyPressed(reverseEngineKey))
        {
            _engines.Call("ReverseEngine");
        }
        if (Input.IsKeyPressed(leftRotaryEngineKey))
        {
            _engines.Call("LeftRotaryEngine");
        }
        if (Input.IsKeyPressed(rightRotaryEngineKey))
        {
            _engines.Call("RightRotaryEngine");
        }
        if (Input.IsKeyPressed(leftSideEngineKey))
        {
            _engines.Call("LeftSideEngine");
        }
        if (Input.IsKeyPressed(rightSideEngineKey))
        {
            _engines.Call("RightSideEngine");
        }
        if (Input.IsKeyPressed(brakeKey))
        {
            _engines.Call("Brake");
        }

        foreach (TurretScript turret in _turrets)
        {
            if (Input.IsKeyPressed(fireKey))
            {
                turret.Fire();
            }
            turret.AimOnScreenPoint(GetViewport().GetMousePosition(), delta);
        }
    }
}

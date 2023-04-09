using Godot;
using System;

public partial class ShipControl : Node
{
	private Node _engines;
   // private List<TurretScript> _turretScripts;

	public Key mainEngineKey = Key.W;
	public Key reverseEngineKey = Key.S;
	public Key leftRotaryEngineKey = Key.A;
	public Key rightRotaryEngineKey = Key.D;
	public Key leftSideEngineKey = Key.Q;
	public Key rightSideEngineKey = Key.E;
	public Key brakeKey = Key.F;

	public Key fireKey = Key.Space;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _engines = GetNode("../Engines");
      //  _turretScripts = new List<TurretScript>(ship.GetComponentsInChildren<TurretScript>());
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

/* TODO: Fix
		foreach (TurretScript turret in _turretScripts)
		{
			if (Input.IsKeyPressed(fireKey))
			{
				turret.Fire();
			}
			turret.AimOnScreenPoint(GetViewport().GetMousePosition());
		}
*/
    }
}

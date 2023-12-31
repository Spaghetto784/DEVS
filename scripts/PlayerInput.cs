using Godot;

namespace Devs.scripts;

public partial class PlayerInput : Node
{
	private Vector2 _movementInput = Vector2.Zero;
	public Vector2 MovementInput => _movementInput;


	public override void _Process(double delta)
	{
		
		_movementInput = new Vector2(
			Input.GetAxis("ui_left" ,"ui_right"),
			Input.GetAxis("ui_up", "ui_down")
		);
		
	}
}

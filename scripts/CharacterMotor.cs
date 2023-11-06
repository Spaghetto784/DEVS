using Godot;

namespace Devs.scripts;

public partial class CharacterMotor : CharacterBody2D
{
	[Export]private float _speed = 300f;
	private Vector2 _movementInput = Vector2.Zero;
	private AnimatedSprite2D _animatedSprite;
	public void MovementPerformed(Vector2 input)
	{
		_movementInput = input.Normalized();
	}
	

	public override void _PhysicsProcess(double delta)
	{
		Velocity = _movementInput * _speed;

		if (Input.IsActionPressed("ui_right"))
		{
			_animatedSprite.Play("run");
		}

		MoveAndSlide();
		
	}
}

using Godot;

namespace Devs.scripts;

public partial class CharacterMotor : CharacterBody2D
{
	[Export]private float _speed = 300f;
	private Vector2 _movementInput = Vector2.Zero;
	private AnimatedSprite2D _animatedSprite; //LA VARIABLE D'ASTRA
	public void MovementPerformed(Vector2 input)
	{
		_movementInput = input.Normalized();
	}
	
	public override void _Ready()
	{
		//Là c'est pour lier la variable avec notre perso Astra
		_animatedSprite = GetNode<AnimatedSprite2D>("Astra");
	}
	public override void _PhysicsProcess(double delta)
	{
		Velocity = _movementInput * _speed;

		//Pour jouer l'animation de run
		if (Input.IsActionPressed("Right") || Input.IsActionPressed("Left"))
		{
			_animatedSprite.Play("run");
		}
		//Pour lorsque le perso est immobile
		else
		{
			_animatedSprite.Play("idle");
		}

		MoveAndSlide();
		
		//pour tourner le perso à gauche
		bool isLeft = Velocity.X < 0;
		_animatedSprite.FlipH = isLeft;
	}
}

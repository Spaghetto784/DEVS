using System.Numerics;
using Godot;
using Plane = Godot.Plane;
using Vector2 = Godot.Vector2;

namespace Devs.scripts;

public partial class CharacterMotor : CharacterBody2D
{
	[Export] private PlayerInput _input;
	[Export] private float _speed = 300f;
	[Export] private float _jump_speed = -400f;
	private Vector2 _movementInput = Vector2.Zero;
	private Vector2 _lastDirection = Vector2.Zero;
	private AnimatedSprite2D _animatedSprite; //LA VARIABLE D'ASTRA
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public void MovementPerformed(Vector2 input)
	{
		_movementInput = input.Normalized();

		if (input.X != 0f)
		{
			_lastDirection = _movementInput;
		}
	}
	
	public override void _Ready()
	{
		//Là c'est pour lier la variable avec notre perso Astra
		_animatedSprite = GetNode<AnimatedSprite2D>("Astra");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		//Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}
		//Handle Jump.
		if (Input.IsActionJustPressed("Up") && IsOnFloor())
		{
			velocity.Y = _jump_speed;
		}
		
		//Mouvements test
		Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * _speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _speed);
		}
		
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

		//pour tourner le perso à gauche
		bool isLeft = _lastDirection.X < 0;
		_animatedSprite.FlipH = isLeft;

		Velocity = velocity;
		MoveAndSlide();
		
		//jump
		//checkJumping(delta);
	}
	
	public override void _Process(double delta)
	{
		//MovementInput
		_movementInput = new Vector2(
			Input.GetAxis("Left" ,"Right"),
			Input.GetAxis("Up", "Down")
		);
		MovementPerformed(_movementInput);
	}

	//private void checkJumping(double delta)
	//{
	//	if (Input.IsActionJustPressed("Up"))
	//	{
	//		_movementInput.Y -= _jump_speed;
	//	}
	//}
}

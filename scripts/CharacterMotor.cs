
using System.Numerics;
using Devs.scripts;
using Godot;
using Plane = Godot.Plane;
using Vector2 = Godot.Vector2;



public partial class CharacterMotor : CharacterBody2D
{
	[Export] private PlayerInput _input;
	[Export] private float _speed = 300f;
	[Export] private float _jump_speed = -420f;
	private Vector2 _movementInput = Vector2.Zero;
	private Vector2 _lastDirection = Vector2.Zero;
	private int _maxJumps = 2; // Maximum number of jumps
	private int _jumpcount = 0; // Number of jumps remaining
	private bool jumped = true;
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
		//initialize le sprite Astra
		_animatedSprite = GetNode<AnimatedSprite2D>("Astra");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		//Mouvements fonctionnelsgit 
		Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * _speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _speed);
		}
		
		//Handle Jump.
		if (_jumpcount < _maxJumps)
		{
			if (Input.IsActionJustPressed("Up"))
			{
				velocity.Y = _jump_speed;
				_jumpcount += 1;
			}
		}

		if (IsOnFloor())
		{
			if (_jumpcount != 0)
			{
				_jumpcount = 0;
				jumped = true;
			}
			//Pour jouer l'animation de run
			if ((Input.IsActionPressed("Right") || Input.IsActionPressed("Left")))
			{
				_animatedSprite.Play("run");
			}
			//Pour crouch
			else if (Input.IsActionPressed("Down") && IsOnFloor())
			{
				_animatedSprite.Play("crouch");
			}
			//Animation de idle donc lobby
			else
			{
				_animatedSprite.Play("idle");
			}
		}
		//Add the gravity.
		else
		{
			velocity.Y += gravity * (float)delta;
			//Animation jump
			if (jumped)
			{
				_jumpcount = 1;
				jumped = false;
			}
			else
			{
				_animatedSprite.Play("jump");
			}
		}
		
		
		//pour tourner le perso à gauche
		bool isLeft = _lastDirection.X < 0;
		_animatedSprite.FlipH = isLeft;

		Velocity = velocity;
		MoveAndSlide();
		
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
}


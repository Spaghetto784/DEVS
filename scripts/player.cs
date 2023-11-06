using Godot;
using System;

public partial class Player : CharacterBody2D {
	public int Speed = 200;
	
	public override void _Ready() {
		// Charge le sprite du personnage
		Sprite playerSprite = GetNode<Sprite>("idle"); 
		// Change la couleur du sprite pour le rendre visible
		// Place le personnage à une position initiale
		Position = new Vector2(100, 100);
		private bool isMoving = false;
	}
	public override void _PhysicsProcess(float delta) {
		// Gestion des entrées clavier
		motion = new Vector2();
		if (Input.IsActionPressed("ui_right") || Input.IsActionPressed("move_right")) {
			motion.x += 1;
		}
		if (Input.IsActionPressed("ui_left") || Input.IsActionPressed("move_left")) {
			motion.x -= 1;
		}
		Sprite playerSprite=GetNode<Sprite>("idle");
		if (motion.x != 0) {
			isMoving = true;
			playerSprite.Play("walk");
			
	   	}else {
			if (isMoving) {
				isMoving = false;
				// Revenir à l'animation idle
				playerSprite.Play("idle");
				}
			}
		if (Input.IsActionPressed("ui_down") || Input.IsActionPressed("move_down")) {
			motion.y += 1;
		}
		if (Input.IsActionPressed("ui_up") || Input.IsActionPressed("move_up")) {
			motion.y -= 1;
		}

		// Gestion des entrées de la manette
		motion += new Vector2(Input.GetJoyAxis(0, 0), Input.GetJoyAxis(0, 1));

		motion = motion.Normalized() * Speed;

		MoveAndSlide(motion);
	}
}

using Godot;
using System;

public partial class MainMenu : Node2D
{
	[Export] public eSceneNames MyeSceneNames;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_tuto_button_up()
	{
		SceneManager.instance.ChangeScene(eSceneNames.Tuto);
		// Replace with function body.
	}
}




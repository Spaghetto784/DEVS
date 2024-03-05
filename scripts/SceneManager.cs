using Godot;
using System;
using System.Collections.Generic;

public enum eSceneNames {
	
	MainMenu = 10,
	Tuto = 20
}

public partial class SceneManager : Node {

	public static SceneManager instance;

	public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>() {
		{eSceneNames.MainMenu, new SceneData("res://scenes/MainMenu.tscn", "MainMenu", false) },
		{eSceneNames.Tuto, new SceneData("res://scenes/world.tscn", "Tuto", true) },
	};

	public override void _Ready() {
		instance = this;
	}

	public void ChangeScene(eSceneNames mySceneName)
	{
		string myPath = sceneDictionary[mySceneName].path;
		GetTree().ChangeSceneToFile(myPath);
	}

}

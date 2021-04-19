using Godot;
using System;
using MenuEntries;


public class SinglePlayerLabel : MenuButton, MenuButtons
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PackedScene singlePlayerScene;
	private SceneTree sceneTree;
	
	public void Callback()
	{
		singlePlayerScene = (PackedScene)ResourceLoader.Load("res://GameScenes/SinglePlayer/SinglePlayer.tscn");
		sceneTree = (SceneTree)Engine.GetMainLoop();
		sceneTree.ChangeSceneTo(singlePlayerScene);
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

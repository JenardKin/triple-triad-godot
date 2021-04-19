using Godot;
using System;
using MenuEntries;

public class Back : MenuButton, MenuButtons
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PackedScene menuScene;
	private SceneTree sceneTree;
	
	public void Callback()
	{
		menuScene = (PackedScene)ResourceLoader.Load("res://GameScenes/Menu/Menu.tscn");
		sceneTree = (SceneTree)Engine.GetMainLoop();
		sceneTree.ChangeSceneTo(menuScene);
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

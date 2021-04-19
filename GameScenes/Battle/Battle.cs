using Godot;
using System;

public class Battle : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PackedScene playerMenu;
	private SceneTree sceneTree;
	public AudioStreamPlayer2D audio = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if( Input.IsActionJustPressed("ui_cancel") )
		{
			playerMenu = (PackedScene)ResourceLoader.Load("res://GameScenes/SinglePlayer/SinglePlayer.tscn");
			sceneTree = (SceneTree)Engine.GetMainLoop();
			sceneTree.ChangeSceneTo(playerMenu);
		}
	}
}

using Godot;
using System;
using MenuEntries;

public class Start : MenuButton, MenuButtons
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PackedScene gameScene;
	private SceneTree sceneTree;
	
	
	public void Callback()
	{
		// create rules dictionary
		foreach( Node node in GetParent().GetChildren() )
		{
			if( node is CheckButton )
			{
				CheckButton checkBtn = (CheckButton)node;
				string name = (string) node.Get("name");
				bool pressed = (bool) checkBtn.Get("pressed");
				if( GlobalVariables.rules.ContainsKey( name ) ){
					// should rules be removed?
					GlobalVariables.rules.Remove( name );
				}
				GlobalVariables.rules.Add( name, pressed );
			}
		}
		
		
		gameScene = (PackedScene)ResourceLoader.Load("res://GameScenes/Battle/Battle.tscn");
		sceneTree = (SceneTree)Engine.GetMainLoop();
		sceneTree.ChangeSceneTo(gameScene);
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

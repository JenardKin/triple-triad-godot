using Godot;
using System;
using System.Collections.Generic;
using MenuEntries;


public class Pointer : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Sprite sprite = null;
	public AudioStreamPlayer2D audio = null;
	public List<Control> entries = new List<Control>();
	public Vector2 prevPosition, nextPosition, delta;
	private int index = 0;
	
	
	public bool SetSelectedEntry(int newIndex)
	{
		if( newIndex >= 0 && newIndex < entries.Count ){
			Control prevEntry = entries[index];
			prevPosition = prevEntry.RectPosition;
			index = newIndex;
			Control selectedEntry = entries[index];
			nextPosition = selectedEntry.RectPosition;
			
			// update sprite position
			delta = nextPosition - prevPosition;			
			sprite.Translate(delta);
			return true;
		}
		else {
			audio = GetNode<AudioStreamPlayer2D>("Sounds/Denied");
			audio.Play();
			return false;
		}
	}
	
	
	public void MoveDown()
	{
		if( SetSelectedEntry( index + 1 ) ){
			audio = GetNode<AudioStreamPlayer2D>("Sounds/Move");
			audio.Play();
		}
	}
	
	
	public void MoveUp()
	{
		if( SetSelectedEntry( index - 1 ) ){
			audio = GetNode<AudioStreamPlayer2D>("Sounds/Move");
			audio.Play();
		}
	}
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if( !GlobalVariables.firstRender )
		{
			audio = GetNode<AudioStreamPlayer2D>("Sounds/Back");
			audio.Play();
		}
		else
		{
			GlobalVariables.firstRender = false;
		}
		
		sprite = GetNode<Sprite>(".");
		Godot.Collections.Array children = sprite.GetParent().GetChildren();
		foreach ( Node entry in children )
		{
			if(entry is Control)
			{
				Control control = (Control)entry;
				if( control.Visible )
				{
					entries.Add(control);
				}
			}
		}
		SetSelectedEntry(0);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if( Input.IsActionJustPressed("ui_down") )
		{
			MoveDown();
		}
		else if( Input.IsActionJustPressed("ui_up") )
		{
			MoveUp();		
		}
		
		if( Input.IsActionJustPressed("ui_accept") )
		{
			Control selectedEntry = entries[ index ];
			// check if the button is disabled?
			// if selected_entry.modulate.a == 1 and not selected_entry.get("disabled"):
			
			if( selectedEntry.HasMethod("Callback") )
			{
				MenuButtons button = (MenuButtons)selectedEntry;
				button.Callback();
			}
			else
			{
				GD.Print( "Selected entry does not have a callback function." );
				audio = GetNode<AudioStreamPlayer2D>("Sounds/Denied");
				audio.Play();
			}
		}
		else if( Input.IsActionJustPressed("ui_cancel") )
		{
			GetTree().Quit();
		}    
	}
}

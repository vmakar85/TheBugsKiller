using Godot;
using System;

public partial class TestScrean : Node2D
{
	AudioStreamPlayer shotSound;
	AudioStreamPlayer smashSound;
	Button button;
	RichTextLabel lText; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shotSound = GetNode<AudioStreamPlayer>(path: "/root/Main/TestScrean/ShotSound");
		smashSound = GetNode<AudioStreamPlayer>(path: "/root/Main/TestScrean/SmashSound");
		button = GetNode<Button>(path: "/root/Main/TestScrean/ShotBtn");
		lText = GetNode<RichTextLabel>(path: "/root/Main/TestScrean/RichTextLabel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int r = Godot.GD.RandRange(0,1);
		int g = Godot.GD.RandRange(0,1);
		int b = Godot.GD.RandRange(0,1);
		lText.AddThemeColorOverride("default_color", new Color(r,g,b,1));
		//Godot.GD.Print("r: " + r + " g: " + g + " b: " + b);
	}
	
	private void _on_shot_btn_pressed()
	{
		shotSound.Play();
	}
	private void _on_smash_btn_pressed()
	{
		smashSound.Play();
	}
}


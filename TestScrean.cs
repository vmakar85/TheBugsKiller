using Godot;
using System;

public partial class TestScrean : Node2D
{
	AudioStreamPlayer shotSound;
	AudioStreamPlayer smashSound;
	Button button;
	RichTextLabel lText;
	AnimatedSprite2D spriteTest;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shotSound = GetNode<AudioStreamPlayer>(path: "/root/Main/TestScrean/ShotSound");
		smashSound = GetNode<AudioStreamPlayer>(path: "/root/Main/TestScrean/SmashSound");
		lText = GetNode<RichTextLabel>(path: "/root/Main/TestScrean/RichTextLabel");
		spriteTest = GetNode<AnimatedSprite2D>(path: "/root/Main/TestScrean/BugSprite");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int r = Godot.GD.RandRange(0, 1);
		int g = Godot.GD.RandRange(0, 1);
		int b = Godot.GD.RandRange(0, 1);
		lText.AddThemeColorOverride("default_color", new Color(r, g, b, 1));
		//Godot.GD.Print("r: " + r + " g: " + g + " b: " + b);
		Godot.GD.Print("delta: " + delta);

	}

	private void _on_shot_btn_pressed()
	{
		shotSound.Play();
	}
	private void _on_smash_btn_pressed()
	{
		smashSound.Play();
	}
	private void _on_dead_btn_pressed()
	{
		spriteTest.Animation = "dead";
	}
	private void _on_run_btn_pressed()
	{
		spriteTest.Animation = "run";
		spriteTest.Play();
	}
	private void _on_bugs_timer_timeout()
	{
		// Replace with function body.
	}

}








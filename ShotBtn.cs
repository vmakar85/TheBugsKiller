using Godot;
using System;

public partial class ShotBtn : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AudioStreamPlayer shotSound = GetNode<AudioStreamPlayer>(path : "/root/Main/TestScrean/ShotSound");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

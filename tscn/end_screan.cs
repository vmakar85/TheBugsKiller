using Godot;
using System;



public partial class end_screan : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<RichTextLabel>("Hit").Text = "Bugs hit : " + main.score;
		GetNode<RichTextLabel>("Accuracy").Text = "Accuracy: " + (main.score / main.miss) * 100 + " % ";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_button_pressed()
	{
		main.score = 0;
		main.miss = 0;
		GetTree().ChangeSceneToFile("res://tscn/Main.tscn");
	}
}



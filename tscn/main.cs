using Godot;
using System;

public partial class main : Node2D
{
	PackedScene scene = GD.Load<PackedScene>("res://tscn/Bug.tscn");
	AnimatedSprite2D animatedSprite2D;
	Bug mob;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Input.VibrateHandheld(50);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_mob_timer_timeout()
	{
		mob = (Bug)scene.Instantiate();
		// Choose a random location on Path2D.
		var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
		mobSpawnLocation.ProgressRatio = GD.Randf();
		// Set the mob's direction perpendicular to the path direction.
		float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;
		// Set the mob's position to a random location.
		mob.Position = mobSpawnLocation.Position;
		// Add some randomness to the direction.
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		//var rE = direction - 30;
		mob.Rotation = direction;
		// Choose the velocity.
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		mob.LinearVelocity = velocity.Rotated(direction);
		// Set animation.
		animatedSprite2D = mob.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite2D.Play("run");
		// Spawn the mob by adding it to the Main scene.
		AddChild(mob);
		//Godot.GD.Print("timer: bzz bzz bzzz.....");
		// add some score, add some dodge hit logik 
	}
}







using Godot;
using System;

public partial class main : Node2D
{
	PackedScene scene = GD.Load<PackedScene>("res://tscn/Bug.tscn");
	PackedScene hudPacked = GD.Load<PackedScene>("res://tscn/hud.tscn");

	Timer gameTimer; 
	
	public static int score { get; set; } = 0;
	public static int miss { get; set; } = 0;
	
	AnimatedSprite2D animatedSprite2D;
	Bug mob;
	hud hudScene; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Input.VibrateHandheld(50);
		hudScene = (hud)hudPacked.Instantiate();
		gameTimer = GetNode<Timer>("GameTimer"); 
		gameTimer.Start();
		hudScene.GetNode<RichTextLabel>("timerText").ZIndex = 10;
		hudScene.GetNode<RichTextLabel>("scoreText").ZIndex = 10;
		AddChild(hudScene);
		
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		hudScene.GetNode<RichTextLabel>("timerText").Text = "Time : " + (int)gameTimer.TimeLeft;
		hudScene.GetNode<RichTextLabel>("scoreText").Text = "Score is : " + score;

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
	private void _on_game_timer_timeout()
	{
		GetTree().ChangeSceneToFile("res://tscn/end_screan.tscn");
	}

}

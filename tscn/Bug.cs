using Godot;
using System;

public partial class Bug : RigidBody2D
{
	AnimatedSprite2D animatedSprite2D;
	AudioStreamPlayer smashSound;
	AnimationPlayer animationPlayer;
	Boolean isDead = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	 animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	 smashSound = GetNode<AudioStreamPlayer>("SmashSound");

	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		QueueFree();
	}
	private void _on_area_2d_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event is InputEventScreenTouch && !isDead) {
			isDead = true;	
			animatedSprite2D.Play("dead");
			LinearVelocity = Vector2.Zero;
			smashSound.Play();
			Input.VibrateHandheld(50);
			Godot.GD.Print("bzz bzz bzzz....."); 

		}
	}
}

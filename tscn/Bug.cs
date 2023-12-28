using Godot;
using System;

public partial class Bug : RigidBody2D
{
	AnimatedSprite2D animatedSprite2D;
	AudioStreamPlayer smashSound;
	AudioStreamPlayer missSound;
	AnimationPlayer animationPlayer;
	Godot.CpuParticles2D cpuParticles2D;
	//Godot.GpuParticles2D gpuParticles2D;

	Boolean isDead = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		smashSound = GetNode<AudioStreamPlayer>("SmashSound");
		missSound = GetNode<AudioStreamPlayer>("MissSound");
		cpuParticles2D = GetNode<Godot.CpuParticles2D>("AnimatedSprite2D/CPUParticles2D");
		//gpuParticles2D = GetNode<Godot.GpuParticles2D>("AnimatedSprite2D/GPUParticles2D");


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
		if (@event is InputEventScreenTouch && !isDead && !missSound.Playing)
		{
			cpuParticles2D.Emitting = true;
			isDead = true;
			animatedSprite2D.Play("dead");
			LinearVelocity = Vector2.Zero;
			smashSound.Play();
			Input.VibrateHandheld(50);
			//	
			
			Godot.GD.Print("bzz bzz bzzz.....");

		}
	}
	private void _on_area_2d_miss_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		if (@event is InputEventScreenTouch && !isDead && !missSound.Playing)
		{
			missSound.Play();
		}
	}
}

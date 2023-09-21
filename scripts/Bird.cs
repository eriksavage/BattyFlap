using Godot;
using System;

public partial class Bird : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public float FlapPower { get; set; }
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SetSprite();

		if(Input.IsActionJustPressed("flap"))
		{
			LinearVelocity = new Vector2(0, -1 * FlapPower);
		}
	}

	private void SetSprite()
	{
		var sprite = GetChild<Sprite2D>(1);
		string birdFall = "res://sprites/bird_fall.png";
		string birdFlap = "res://sprites/bird_flap.png";
		
		sprite.Texture = LinearVelocity.Y < 0 ? (Texture2D)GD.Load(birdFlap) : (Texture2D)GD.Load(birdFall);
	}
}

using System;
using Godot;

namespace Projects.scripts;
public partial class Bat : RigidBody2D
{
	[Export]
	public float FlapPower { get; set; }

	private AnimatedSprite2D _animatedSprite;
	public override void _Ready()
	{
		_animatedSprite = GetChild<AnimatedSprite2D>(1);
	}

	public override void _Process(double delta)
	{
		// prevents sprite from getting rotated
		RotationDegrees = 0;

		if (Input.IsActionJustPressed("flap"))
		{
			LinearVelocity = new Vector2(0, -1 * FlapPower);
			_animatedSprite.Play("flap");
		}
		else if (LinearVelocity.Y > 0)
		{
			_animatedSprite.Play("fall");
		}
	}
}

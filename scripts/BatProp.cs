using Godot;

namespace Projects.scripts;
public partial class BatProp : RigidBody2D
{
	private AnimatedSprite2D _animatedSprite;
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		GravityScale = 0;
		_animatedSprite.Play("sleep");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

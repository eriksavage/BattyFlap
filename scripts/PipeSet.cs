using Godot;
using System;

public partial class PipeSet : Node2D
{
	[Export]
	public float MoveSpeed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var pipeSpawner = GetParent().GetNode<Node2D>("PipeSpawner");
		Position = pipeSpawner.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		MoveLeft((float)delta);

		if (GlobalPosition.X < -500)
		{
			QueueFree();
		}
	}

	private void MoveLeft(float delta)
	{
		Position = new Vector2(Position.X + (-1 * MoveSpeed * delta), Position.Y);
	}
}

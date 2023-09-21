using Godot;
using System;

public partial class SpawnPipeSet : Node2D
{
	[Export]
	public int SpawnRange;
	
	[Export]
	public int MinDeltaY;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_timer_timeout()
	{
				SetSpawnPosition();
				SpawnPipeSetInstance();
	}

	private void SetSpawnPosition()
	{
		var newPositionY = GenerateNewPositionY();

		Position = new Vector2(Position.X, newPositionY);
	}

	private void SpawnPipeSetInstance()
	{
		var scene = GD.Load<PackedScene>("res://scenes/PipeSet.tscn");
		GetParent().AddChild(scene.Instantiate());
	}

	private int GenerateNewPositionY()
	{
		bool isGreaterThanMin = false;
		int heightPosition = new Random().Next(-SpawnRange, SpawnRange);
		float deltaY;

		while (!isGreaterThanMin)
		{
			deltaY = Math.Abs(heightPosition - Position.Y);

			if (deltaY > MinDeltaY)
			{
				isGreaterThanMin = true;
			}
			else
			{
				heightPosition = new Random().Next(-SpawnRange, SpawnRange);
			}
		}

		return heightPosition;
	}
}





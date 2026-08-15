using Godot;
using System;

namespace Projects.scripts;
public partial class FormationSpawner : Node2D
{
	[Export]
	public int SpawnRange;
	
	[Export]
	public int MinDeltaY;
	
	public override void _Ready()
	{
		var viewportHeight = GetViewport().GetVisibleRect().Size.Y;
		GD.Print("viewportHeight: " + viewportHeight);
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
		var scene = GD.Load<PackedScene>("res://scenes/FormationSet.tscn");
		GetParent().AddChild(scene.Instantiate());
	}

	private int GenerateNewPositionY()
	{
		bool isGreaterThanMin = false;
		int heightPosition = new Random().Next(-SpawnRange, SpawnRange);

		while (!isGreaterThanMin)
		{
			var deltaY = Math.Abs(heightPosition - Position.Y);

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





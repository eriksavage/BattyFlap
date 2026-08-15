using Godot;

namespace Projects.scripts;
public partial class FormationSet : Node2D
{
	[Export]
	public float MoveSpeed;

	[Export]
	public float FormationGap;
	
	private bool _passed;
	public override void _Ready()
	{
		var stalactite = GetNode<StaticBody2D>("Stalactite");
		stalactite.Position = new Vector2(stalactite.Position.X, -FormationGap / 2);
		
		var stalagmite = GetNode<StaticBody2D>("Stalagmite");
		stalagmite.Position = new Vector2(stalagmite.Position.X, FormationGap / 2);

		var formationSpawner = GetParent().GetNode<Node2D>("FormationSpawner");
		Position = formationSpawner.Position;
	}

	public override void _Process(double delta)
	{
		MoveLeft((float)delta);
		EvaluateFormationPassed();
			
		if (GlobalPosition.X < -500)
		{
			QueueFree();
		}
	}

	private void MoveLeft(float delta)
	{
		Position = new Vector2(Position.X + (-1 * MoveSpeed * delta), Position.Y);
	}
	private void EvaluateFormationPassed()
	{
		var batPosition = GetParent().GetNode<Node2D>("Bat").GlobalPosition.X;
		var pipePosition = GlobalPosition.X;
		
		if (!_passed && (batPosition > pipePosition))
		{
			var eventBus = GetNode<EventBus>("/root/EventBus");
			eventBus.EmitFormationPassed();	
			_passed = true;
		}

	}
}



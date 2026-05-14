using Godot;

namespace Projects.scripts;
public partial class PipeSet : Node2D
{
	[Export]
	public float MoveSpeed;
	// Called when the node enters the scene tree for the first time.
	
	private bool _passed;
	public override void _Ready()
	{
		var pipeSpawner = GetParent().GetNode<Node2D>("PipeSpawner");
		Position = pipeSpawner.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		MoveLeft((float)delta);
		EvaluatePipesPassed();
			
		if (GlobalPosition.X < -500)
		{
			QueueFree();
		}
	}

	private void MoveLeft(float delta)
	{
		Position = new Vector2(Position.X + (-1 * MoveSpeed * delta), Position.Y);
	}
	private void EvaluatePipesPassed()
	{
		var batPosition = GetParent().GetNode<Node2D>("Bat").GlobalPosition.X;
		var pipePosition = GlobalPosition.X;
		
		if (!_passed && (batPosition > pipePosition))
		{
			var eventBus = GetNode<EventBus>("/root/EventBus");
			eventBus.EmitPipesPassed();	
			_passed = true;
		}

	}
}



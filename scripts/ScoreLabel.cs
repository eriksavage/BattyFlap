using Godot;

namespace Projects.scripts;
public partial class ScoreLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	private int _score;
	private EventBus _eventBus;
	public override void _Ready()
	{
		_eventBus = GetNode<EventBus>("/root/EventBus");
		_eventBus.PipesPassed += IncrementScore;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void IncrementScore()
	{
		_score += 1;
		Text = $"Score: {_score}";
	}
}

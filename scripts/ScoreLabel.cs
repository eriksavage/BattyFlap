using Godot;

namespace Projects.scripts;
public partial class ScoreLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	private int _score;
	private bool _canIncrement = true;
	private EventBus _eventBus;
	public override void _Ready()
	{
		_eventBus = GetNode<EventBus>("/root/EventBus");
		_eventBus.PipesPassed += IncrementScore;
		_eventBus.BatKnockedOut += SetCanIncrementFalse;
	}
	
	private void IncrementScore()
	{
		_score = _canIncrement ? _score + 1 : _score;
		Text = $"Score: {_score}";
	}

	private void SetCanIncrementFalse()
	{
		_canIncrement = false;
	}
}

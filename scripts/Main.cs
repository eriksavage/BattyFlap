using Godot;

namespace Projects.scripts;
public partial class Main : Node2D
{
	private int _score;
	private bool _canIncrement = true;
	private EventBus _eventBus;
	public override void _Ready()
	{
		_eventBus = GetNode<EventBus>("/root/EventBus");
		_eventBus.PipesPassed += IncrementScore;
		_eventBus.BatKnockedOut += OnBatKnockedOut;
	}

	private void IncrementScore()
	{
		_score = _canIncrement ? _score + 1 : _score;
		GetNode<Label>("UserInterface/Score").Text = $"Score: {_score}";
	}

	private void OnBatKnockedOut()
	{
		_canIncrement = false;
		
	}
}

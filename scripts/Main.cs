using Godot;

namespace Projects.scripts;
public partial class Main : Node2D
{
	private int _score;
	private bool _canIncrement = true;
	private EventBus _eventBus;
	private GameState _gameState;
	private Label _scoreLabel;
	public override void _Ready()
	{
		_gameState = GetNode<GameState>("/root/GameState");
		_eventBus = GetNode<EventBus>("/root/EventBus");
		_scoreLabel = GetNode<Label>("UserInterface/Score");
		_eventBus.FormationPassed += IncrementScore;
		_eventBus.BatKnockedOut += OnBatKnockedOut;
		_eventBus.RestartRequested += OnRestartRequested;
	}

	public override void _ExitTree()
	{
		_eventBus.FormationPassed -= IncrementScore;
		_eventBus.BatKnockedOut -= OnBatKnockedOut;
		_eventBus.RestartRequested -= OnRestartRequested;
	}

	private void IncrementScore()
	{
		_score = _canIncrement ? _score + 1 : _score;
		_scoreLabel.Text = $"Score: {_score}";
	}

	private void OnBatKnockedOut()
	{
		_canIncrement = false;
		_scoreLabel.Visible = false;

		if (_score > _gameState.BestScore)
		{
			_gameState.BestScore = _score;	
		}
		
		var gameOver = GD.Load<PackedScene>("res://scenes/GameOver.tscn").Instantiate<GameOver>();
		gameOver.Score = _score;
		gameOver.BestScore = _gameState.BestScore;
		AddChild(gameOver);
	}

	private void OnRestartRequested()
	{
		_canIncrement = true;
		_scoreLabel.Visible = true;
		Engine.TimeScale = 1;
		
		var titleScene = GD.Load<PackedScene>("res://scenes/Title.tscn");
		GetTree().ChangeSceneToPacked(titleScene);
		
	}
}

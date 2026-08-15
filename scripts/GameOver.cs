using Godot;

namespace Projects.scripts;
public partial class GameOver : Control
{
	public int Score;
	public int BestScore;
	
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Visible;
		GetNode<Label>("Panel/MarginContainer/VBoxContainer/GridContainer/Score").Text = Score.ToString();
		GetNode<Label>("Panel/MarginContainer/VBoxContainer/GridContainer/Best").Text = BestScore.ToString();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("confirm"))
		{
			RestartGame();	
		}
	}
	private void OnPlayAgainButtonUp()
	{
		RestartGame();
	}

	private void RestartGame()
	{
		var eventBus = GetNode<EventBus>("/root/EventBus");
		eventBus.EmitRestartRequested();
		QueueFree();		
	}
}

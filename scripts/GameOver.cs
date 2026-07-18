using Godot;

namespace Projects.scripts;
public partial class GameOver : Control
{
	public int Score;
	public int BestScore;
	
	public override void _Ready()
	{
		GetNode<Label>("Panel/MarginContainer/VBoxContainer/GridContainer/Score").Text = Score.ToString();
		GetNode<Label>("Panel/MarginContainer/VBoxContainer/GridContainer/Best").Text = BestScore.ToString();
	}

	private void OnPlayAgainButtonUp()
	{
		var eventBus = GetNode<EventBus>("/root/EventBus");
		eventBus.EmitRestartRequested();
		QueueFree();
	}
}

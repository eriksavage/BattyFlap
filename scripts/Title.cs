using Godot;

namespace Projects.scripts;

public partial class Title : Node2D
{
    [Export] 
    public PackedScene TargetScene { get; set; }

    public override async void _Process(double delta)
    {
        if (TargetScene != null && Input.IsActionJustPressed("flap"))
        {
            SetProcess(false);

            var sprite = GetNode<AnimatedSprite2D>("BatProp/AnimatedSprite2D");
            sprite.Play("stretch");
            
            await ToSignal(sprite, AnimatedSprite2D.SignalName.AnimationFinished);
            GetTree().ChangeSceneToPacked(TargetScene);    
        }
    }
}

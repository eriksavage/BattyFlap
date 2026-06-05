using Godot;

namespace Projects.scripts;

public partial class Title : Node2D
{
    [Export] 
    public PackedScene TargetScene { get; set; }

    // Changed to async void so we can use 'await' inside the loop
    public override async void _Process(double delta)
    {
        // 1. Changed to IsActionJustPressed so the animation doesn't constantly restart
        if (TargetScene != null && Input.IsActionJustPressed("flap"))
        {
            // Disable processing immediately so the user can't trigger this multiple times
            SetProcess(false);

            var sprite = GetNode<AnimatedSprite2D>("BatProp/AnimatedSprite2D");
            
            // 2. Start the stretch animation
            sprite.Play("stretch");
            
            // 3. Pause execution right here until the animation finishes playing
            await ToSignal(sprite, AnimatedSprite2D.SignalName.AnimationFinished);
            
            // 4. Safely switch the scene
            GetTree().ChangeSceneToPacked(TargetScene);    
        }
    }
}

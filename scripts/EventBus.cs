using Godot;

namespace Projects.scripts;
public partial class EventBus : Node
{
    [Signal]
    public delegate void PipesPassedEventHandler();
    
    [Signal]
    public delegate void BatKnockedOutEventHandler();

    // Helper method so other classes can emit this easily
    public void EmitPipesPassed()
    {
        EmitSignal(SignalName.PipesPassed);
    }

    public void EmitBatKnockedOut()
    {
        EmitSignal(SignalName.BatKnockedOut);
    }
}

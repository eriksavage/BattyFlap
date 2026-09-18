using Godot;

namespace Projects.scripts;
public partial class BatRest : Node2D
{
    private float _moveSpeed = 40;

    public override void _Process(double delta)
    {
        MoveLeft((float)delta);
			
        if (GlobalPosition.X < -500)
        {
            QueueFree();
        }
    }

    private void MoveLeft(float delta)
    {
        _moveSpeed = _moveSpeed <= Constants.MOVEMENT_SPEED ? _moveSpeed += 2 : Constants.MOVEMENT_SPEED;
        Position = new Vector2(Position.X + (-1 * _moveSpeed * delta), Position.Y);
    }
}

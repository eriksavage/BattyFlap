using Godot;

namespace Projects.scripts;
public partial class Bat : RigidBody2D
{
	[Export]
	public float FlapPower { get; set; }

	[Export]
	public float KoSpinSpeed { get; set; }

	private float _koRotation;
	
	private AnimatedSprite2D _animatedSprite;
	private bool _knockedOut;
	private float _knockedOutTimeScale = 1.0f;
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		ContactMonitor = true;
		MaxContactsReported = 1;
		BodyEntered += OnBodyEnteredFoo;
	}

	public override void _Process(double delta)
	{
		if (_knockedOut)
		{
			_koRotation += KoSpinSpeed * (float)delta;
			RotationDegrees = _koRotation;
		
			_knockedOutTimeScale = _knockedOutTimeScale <= 0.15f ? _knockedOutTimeScale : _knockedOutTimeScale - ((float)delta * 2.0f);
			Engine.TimeScale = _knockedOutTimeScale;
			
			_animatedSprite.Play("ko");			
			_animatedSprite.SpeedScale = (float)(1.0 / _knockedOutTimeScale);
			
		}
		else
		{
			RotationDegrees = 0;
	
			if (Input.IsActionJustPressed("flap"))
			{
				LinearVelocity = new Vector2(0, -1 * FlapPower);
				_animatedSprite.Play("flap");
			}
			else if (LinearVelocity.Y > 0)
			{
				_animatedSprite.Play("fall");
			}
		}
	}
	private void OnBodyEnteredFoo(Node body)
	{
		if (body is StaticBody2D)
		{
			_knockedOut = true;
			var eventBus = GetNode<EventBus>("/root/EventBus");
			eventBus.EmitBatKnockedOut();	
		}
	}
}

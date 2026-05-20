using Godot;
using System;
using System.Globalization;

public partial class Pipes : Node2D
{

	const float SCROLL_SPEED = 120.0f;
	[Export] private VisibleOnScreenNotifier2D _notifier;
	[Export] Area2D _upperPipe;
	[Export] Area2D _lowerPipe;
	[Export] Area2D _laser;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_notifier.ScreenExited += OffScreen;
		_upperPipe.BodyEntered += OnPipeBodyEntered;
		_lowerPipe.BodyEntered += OnPipeBodyEntered;
		_laser.BodyExited += OnLaserExited;
	}

    private void OnLaserExited(Node2D body)
    {
		if (body is Tappy)
		{
			GD.Print("points scored");	
		}
    }


    private void OnPipeBodyEntered(Node2D body)
    {
		if (body is Tappy)
		{
			(body as Tappy).Die();
		}
    }


    private void OffScreen()
    {
		GD.Print("Pipes removed");
		QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		Position -=new Vector2(SCROLL_SPEED*(float)delta,0);
	}
}

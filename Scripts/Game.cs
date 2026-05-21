using Godot;
using System;

public partial class Game : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] private Timer _spawnTimer;
	[Export] private Node2D _pipesHolder;
	[Export] private Marker2D _upperMarker;
	[Export] private Marker2D _lowerMarker;

	private PackedScene _pipes;

	 

	

	public override void _Ready()
	{
		_pipes = GD.Load<PackedScene>("res://Scenes/Pipes.tscn");
		_spawnTimer.Timeout += SpawnPipe;
	}

	private void SpawnPipe()
	{
		Pipes pipes = _pipes.Instantiate<Pipes>();
		pipes.Position = new Vector2(_upperMarker.Position.X, (float)GD.RandRange(_upperMarker.Position.Y, _lowerMarker.Position.Y));
		_pipesHolder.AddChild(pipes);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

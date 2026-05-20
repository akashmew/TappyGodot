using Godot;
using System;

public partial class GameUi : Control
{
	// Called when the node enters the scene tree for the first time.
	[Export] Label _gameOverLabel;
	[Export] Label _pressSpaceLabel;

	[Export] Timer _gameOverTimer;

	[Export] AudioStreamPlayer _gameOverMusic;
	public override void _Ready()
	{

		SignalHub.Instance.OnTappyDied += OnTappyDied;
		_gameOverTimer.Timeout += ShowPlayAgain;
	}

	private void ShowPlayAgain()
	{
		_gameOverLabel.Hide();
		_pressSpaceLabel.Show();
    }


    public override void _ExitTree()
    {
       SignalHub.Instance.OnTappyDied -= OnTappyDied;
    }

	private void OnTappyDied()
	{

		_gameOverLabel.Show();
		_gameOverMusic.Play();
		_gameOverTimer.Start();
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

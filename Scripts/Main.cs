using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Main : Control
{
    [Export] private Label _highScoreLabel;

    public override void _Ready()
    {
        GetTree().Paused = false;
        _highScoreLabel.Text = ScoreManager.Instance.HighScore.ToString("D3");
    }


    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_cancel") || @event.IsActionPressed("jump"))
        {
            GameManager.LoadGameScene();
        }
    }

    
}
